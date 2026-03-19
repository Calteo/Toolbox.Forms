using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace Toolbox.Forms
{
	/// <summary>
	/// A pool of worker threads that can be used to execute tasks in the background. This component manages a collection of worker threads and provides methods to add tasks to the pool, monitor their progress, and handle their completion. 
	/// It is designed to simplify the process of executing tasks concurrently without blocking the main thread of an application.
	/// </summary>
	public partial class WorkerPool : Component
	{
		public WorkerPool()
		{
			InitializeComponent();
		}

		public WorkerPool(IContainer container)
		{
			container.Add(this);

			InitializeComponent();			
		}

		#region Ownwe
		private Control? _owner;
		/// <summary>
		/// The control hosting the worker pool. 
		/// This property is set when the component is added to a control in the designer. 
		/// It can be used to access the control's properties and methods from within the worker pool, allowing for better integration with the user interface.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Control? Owner
		{
			get => _owner;
			set
			{
				if (_owner == value) return;
				if (Running)
					throw new InvalidOperationException("Cannot change owner while worker pool is running.");

				OwnerForm?.FormClosing -= OwnerFormClosing;
				OwnerForm = null;
				
				_owner = value;
			}
		}		

		private Form? OwnerForm { get; set; }

		private void OwnerFormClosing(object? sender, FormClosingEventArgs e)
		{
			if (ClosingBehavior == ClosingBehavior.None 
				|| e.CloseReason == CloseReason.WindowsShutDown 
				|| e.CloseReason == CloseReason.TaskManagerClosing
				|| e.CloseReason == CloseReason.ApplicationExitCall) 
				return;

			if (Running)
			{
				switch (ClosingBehavior)
				{
					case ClosingBehavior.CancelClose:
						e.Cancel = true;
						Cancel();
						ClosePending = true;
						break;
					case ClosingBehavior.CancelWaitClose:
						e.Cancel = true;
						OwnerForm?.UseWaitCursor = true;
						Cancel();
						ClosePending = true;
						break;
					case ClosingBehavior.CancelHideClose:
						e.Cancel = true;
						OwnerForm?.ShowInTaskbar = false;
						OwnerForm?.Hide();
						Cancel();
						ClosePending = true;
						break;
					case ClosingBehavior.QueryClose:
						var result = MsgBox.Show(
							Owner!,
							"Tasks are still running.\r\nDo you want to close anyway?",
							OwnerForm?.Text ?? "Confirm Close",
							MessageBoxButtons.OKCancel,
							MessageBoxIcon.Warning);
						if (result == DialogResult.OK)
							Cancel();							
						else
							e.Cancel = true;						
						break;
					case ClosingBehavior.BlockClose:
						MsgBox.Show(
							Owner!,
							"Tasks are still running.\r\nClosing not possible.",
							OwnerForm?.Text ?? "Confirm Close",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);							
						e.Cancel = true;
						break;
					default:
						break;
				}
			}
		}
		#endregion

		public bool ClosePending { get; private set; }

		/// <inheritdoc />
		public override ISite? Site
		{
			get => base.Site;
			set
			{
				base.Site = value;

				if (value == null) return;

				var host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;

				if (host?.RootComponent is Control control)
				{
					Owner = control;
				}
			}
		}

		/// <summary>
		/// Gets or sets the behavior that determines how the worker pool handles active tasks when it is closed.
		/// </summary>
		/// <remarks>Set this property to specify whether the worker pool should wait for all active tasks to complete
		/// before closing, or cancel ongoing tasks immediately. The selected behavior affects how shutdown operations are
		/// performed and may impact task completion guarantees.</remarks>
		[Description("Determines the behavior of the worker pool when it is closed. This property can be set to specify whether the worker pool should wait for all active tasks to complete before closing, or if it should cancel any ongoing tasks immediately.")]
		[DefaultValue(ClosingBehavior.None)]
		public ClosingBehavior ClosingBehavior { get; set; } = ClosingBehavior.None;

		private int _workerId;
		private string GetWorkerId() => $"Work#{Interlocked.Increment(ref _workerId)}";

		/// <summary>
		/// Is the worker pool currently running tasks. This property indicates whether there are active tasks being executed in the worker pool.
		/// </summary>
		public bool Running => _workerCount > 0;

		private int _workerCount;
		
		internal void IncrementWorkerCount()
		{
			var count = Interlocked.Increment(ref _workerCount);

			if (count == 1)
			{				
				OnStarted();
			}
		}

		internal void DecrementWorkerCount()
		{
			var count = Interlocked.Decrement(ref _workerCount);

			if (count == 0)
			{
				IsCanceled = false;
				OnStopped();
				if (ClosePending && OwnerForm != null)
				{
					OwnerForm.Invoke(OwnerForm.Close);
				}					
			}
		}

		public event EventHandler<EventArgs>? Started;
		public event EventHandler<EventArgs>? Stopped;

		private void OnStarted()
		{
			if (OwnerForm == null)
			{
				OwnerForm = Owner?.FindForm();
				OwnerForm?.FormClosing += OwnerFormClosing;
			}

			if (Started == null) return;
			if (Owner != null && Owner.InvokeRequired)
				Owner.Invoke(() => Started(this, EventArgs.Empty));
			else
				Started(this, EventArgs.Empty);
		}

		private void OnStopped()
		{
			if (Stopped == null) return;

			if (Owner != null && Owner.InvokeRequired)
				Owner.Invoke(() => Stopped(this, EventArgs.Empty));
			else
				Stopped(this, EventArgs.Empty);
		}

		public event EventHandler<WorkItemEventArgs>? ItemStarted;
		internal void OnItemStarted(string name)
		{
			if (ItemStarted == null) return;

			var args = new WorkItemEventArgs(name);

			if (Owner != null && Owner.InvokeRequired)
				Owner.Invoke(() => ItemStarted(this, args));
			else
				ItemStarted(this, args);
		}
		public event EventHandler<WorkItemEventArgs>? ItemStopped;
		internal void OnItemStopped(string name)
		{
			if (ItemStopped == null) return;

			var args = new WorkItemEventArgs(name);

			if (Owner != null && Owner.InvokeRequired)
				Owner.Invoke(() => ItemStopped(this, args));
			else
				ItemStopped(this, args);
		}

		public void Cancel()
		{
			IsCanceled = true;
		}

		internal bool IsCanceled { get; private set; }

		public bool Enqueue<TP>(
			Action<IWorker<TP>> action,
			Action<IWorkResult>? completed = null)
		{
			return Enqueue<object?, TP, object?>(
				GetWorkerId(),
				(worker, _) =>
				{
					action(worker);
					return null;
				},
				null,
				null,
				completed);
		}

		public bool Enqueue<TP>(
			Action<IWorker<TP>> action,
			Action<string, int, TP>? progress = null,
			Action<IWorkResult>? completed = null)
		{
			return Enqueue<object?, TP, object?>(
				GetWorkerId(),
				(worker, _) =>
				{
					action(worker);
					return null;
				},
				null,
				progress,
				completed);
		}

		public bool Enqueue<TP>(
			string name,
			Action<IWorker<TP>> action,
			Action<string, int, TP>? progress = null,
			Action<IWorkResult>? completed = null)
		{
			return Enqueue<object?, TP, object?>(
				name,
				(worker, _) =>
				{
					action(worker);
					return null;
				},
				null,
				progress,
				completed);
		}

		public bool Enqueue<TI, TP, TO>(
			Func<IWorker<TP>, TI, TO> action,
			TI input,
			Action<string, int, TP>? progress = null,
			Action<IWorkResult<TI,TO>>? completed = null)
		{
			return Enqueue<TI, TP, TO>(GetWorkerId(), action, input, progress, completed);
		}

		public bool Enqueue<TI, TP, TO>(
			string name, 
			Func<IWorker<TP>, TI, TO> action, 
			TI input, 
			Action<string, int, TP>? progress = null, 
			Action<IWorkResult<TI, TO>>? completed = null) 
		{
			if (IsCanceled) return false;

			IncrementWorkerCount();

			var item = new WorkItem<TI, TP, TO>(this, name, action, input, progress, completed);

			ThreadPool.QueueUserWorkItem(item.Execute);

			return true;
		}
	}
}