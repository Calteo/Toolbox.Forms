using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Forms
{
	public interface IWorkResult
	{
		public string Name { get; }
		public bool Canceled { get; }
		public Exception? Exception { get; }
	}

	public interface IWorkResult<TI, TO> : IWorkResult
	{
		public TI Input { get; }
		public TO Output { get; }
	}

	internal class WorkResult<TI, TO> : IWorkResult<TI, TO>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WorkResult{TI, TO}"/>  class.
		/// </summary>
		/// <param name="name">The name of the operation associated with this result. Cannot be null.</param>
		/// <param name="input">The input value that was provided to the operation.</param>
		/// <param name="output">The output value produced by the operation.</param>
		/// <param name="canceled">A value indicating whether the operation was canceled. Set to <see langword="true"/> if the operation was
		/// canceled; otherwise, <see langword="false"/>.</param>
		/// <param name="exception">The exception that occurred during the operation, or <see langword="null"/> if no exception was thrown.</param>		
		public WorkResult(string name, TI input, TO output, bool canceled, Exception? exception)
		{
			Name = name;
			Input = input;
			Output = output;
			Canceled = canceled;
			Exception = exception;
		}

		public string Name { get; }
		public bool Canceled { get; }
		public Exception? Exception { get; }
		public TI Input { get; }
		public TO Output { get; }
	}
}
