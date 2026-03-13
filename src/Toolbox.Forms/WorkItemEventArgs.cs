using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Forms
{
	public class WorkItemEventArgs : EventArgs
	{
		public WorkItemEventArgs(string name)
		{
			Name = name;
		}

		public string Name { get; }
	}
}
