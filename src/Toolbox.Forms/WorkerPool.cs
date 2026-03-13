using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

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

		/// <summary>
		/// The control hosting the worker pool. 
		/// This property is set when the component is added to a control in the designer. 
		/// It can be used to access the control's properties and methods from within the worker pool, allowing for better integration with the user interface.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Control? Owner { get; set; }

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
					Owner = control;
			}
		}

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
			}
		}

		public event EventHandler<EventArgs>? Started;
		public event EventHandler<EventArgs>? Stopped;

		private void OnStarted()
		{
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

		public bool Enqueue<TI, TP, TO>(
			Func<IWorker<TP>, TI, TO> action,
			TI input,
			Action<string, int, TP>? progress = null,
			Action<string, TI, TO, bool, Exception?>? completed = null)
		{
			return Enqueue(GetWorkerId(), action, input, progress, completed);
		}

		public bool Enqueue<TI, TP, TO>(string name, 
			Func<IWorker<TP>, TI, TO> action, 
			TI input, 
			Action<string, int, TP>? progress = null, 
			Action<string, TI, TO, bool, Exception?>? completed = null) 
		{
			if (IsCanceled) return false;

			IncrementWorkerCount();

			var item = new WorkItem<TI, TP, TO>(this, name, action, input, progress, completed);

			ThreadPool.QueueUserWorkItem(item.Execute);

			return true;
		}
	}
}