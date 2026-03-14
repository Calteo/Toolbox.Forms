using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Toolbox.Forms
{
	/// <summary>
	/// Represents a work item within the <see cref="WorkerPool">.
	/// </summary>
	internal class WorkItem<TI, TP, TO> : IWorker<TP>
	{
		public WorkItem(WorkerPool pool, 
			string name, 
			Func<IWorker<TP>, TI, TO> action, 
			TI input, 
			Action<string, int, TP>? progress, 
			Action<IWorkResult<TI, TO>>? completed)
		{
			Pool = pool;
			Name = name;
			Action = action;
			Input = input;			
			Progress = progress;
			Completed = completed;
		}

		public WorkerPool Pool { get; }
		public string Name { get; }
		public Func<IWorker<TP>, TI, TO> Action { get; }
		public TI Input { get; }
		public Action<string, int, TP>? Progress { get; }
		public Action<IWorkResult<TI, TO>>? Completed { get; }
		public bool IsCancelled => Pool.IsCanceled;
				
		internal void Execute(object? state)
		{
			Pool.OnItemStarted(Name);
			try
			{				
				var output = Action(this, Input);

				OnCompleted(Name, Input, output, IsCancelled, null);
			}
			catch (Exception exception)
			{
				OnCompleted(Name, Input, default!, false, exception);
			}
			finally
			{
				Pool.OnItemStopped(Name);
				Pool.DecrementWorkerCount();
			}
		}

		private void OnCompleted(string name, TI input, TO output, bool canceled, Exception? exception)
		{
			if (Completed != null)
			{
				var result = new WorkResult<TI, TO>(name, input, output, canceled, exception);

				Pool.Owner!.Invoke(() => Completed(result));
			}
		}

		void IWorker<TP>.ReportProgress(int id, TP arg)
		{
			if (Progress != null)
			{
				Pool.Owner!.Invoke(() => Progress(Name, id, arg));
			}
		}
	}
}
