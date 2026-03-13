using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Forms
{
	public interface IWorker
	{
		/// <summary>
		/// Name of the work item. This property is used to identify the work item within the worker pool and can be used for logging, debugging, or displaying progress information to the user. It provides a way to track and manage individual tasks within the pool, especially when multiple tasks are being executed concurrently.
		/// </summary>
		public string Name { get; }
		public bool IsCancelled { get; }	
	}

	/// <summary>
	/// Interface to the worker in the <see cref="WorkerPool">. 
	/// </summary>
	public interface IWorker<T>: IWorker
	{
		public void ReportProgress(int id, T arg);
	}
}
