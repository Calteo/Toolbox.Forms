using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Toolbox.Forms.Demo.Controls
{
	public partial class MsgBoxControl : UserControl
	{
		public MsgBoxControl()
		{
			InitializeComponent();

			comboBoxButtons.Items.AddRange([.. Enum.GetValues(typeof(MessageBoxButtons))]);
			comboBoxButtons.SelectedItem = MessageBoxButtons.OK;

			comboBoxIcons.Items.AddRange([.. Enum.GetValues(typeof(MessageBoxIcon)).Cast<MessageBoxIcon>().Distinct()]);			
			comboBoxIcons.SelectedItem = MessageBoxIcon.Information;
		}

		private void ButtonShowClick(object sender, EventArgs e)
		{
			var owner = checkBoxNoOwner.Checked ? null : this;
			var buttons = (MessageBoxButtons)comboBoxButtons.SelectedItem!;
			var icon = (MessageBoxIcon)comboBoxIcons.SelectedItem!;

			var result = MsgBox.Show(owner, textBoxText.Text, null, buttons, icon, textBoxDetails.Text);

			labelResultValue.Text = result.ToString();
		}
	}
}
