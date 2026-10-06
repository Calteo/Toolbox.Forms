using Toolbox.ComponentModel;
using Toolbox.Forms.Demo.Models;

namespace Toolbox.Forms.Demo.Controls
{
	public partial class ObjectListViewControl : UserControl
	{
		public ObjectListViewControl()
		{
			InitializeComponent();
			objectListView.DataSource = Datas;
		}

		private BindableList<Data> Datas { get; } = [];

		private void ButtonAddClick(object sender, EventArgs e)
		{
			Datas.Add(new Data { Id = Datas.Count + 1, Name = $"Some Data #{Datas.Count + 1}" });
		}
	}
}
