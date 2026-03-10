using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Toolbox.Forms
{
	internal partial class MsgBoxDetailsForm : Form
	{
		public MsgBoxDetailsForm()
		{
			InitializeComponent();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string DetailsText
		{
			get => textBox.Text;
			internal set => textBox.Text = value;
		}


		private void MsgBoxDetailsFormLoad(object sender, EventArgs e)
		{
			textBox.SelectionStart = 0;
			textBox.SelectionLength = 0;

			textBox.Focus();
		}

		private void TextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				e.SuppressKeyPress = true;
				Close();
			}
		}
	}
}
