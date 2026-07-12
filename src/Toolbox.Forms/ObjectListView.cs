using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Toolbox.Forms
{
	/// <summary>
	/// Control for displaying a list of objects
	/// </summary>	
	public class ObjectListView : Control
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true), Category("Data"), Description("Data source of the objects")]
		public object? DataSource { get; set; }

		[ListBindable(false)]
		[Browsable(true), Description("List of data columns")]
		public List<ObjectListViewColumn> Columns { get; } = [];
	}
}
