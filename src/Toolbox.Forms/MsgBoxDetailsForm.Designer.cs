namespace Toolbox.Forms
{
	partial class MsgBoxDetailsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			textBox = new TextBox();
			SuspendLayout();
			// 
			// textBox
			// 
			textBox.Dock = DockStyle.Fill;
			textBox.Location = new Point(0, 0);
			textBox.MaxLength = 100000;
			textBox.Multiline = true;
			textBox.Name = "textBox";
			textBox.ReadOnly = true;
			textBox.ScrollBars = ScrollBars.Both;
			textBox.Size = new Size(859, 487);
			textBox.TabIndex = 0;
			textBox.WordWrap = false;
			textBox.KeyDown += TextBoxKeyDown;
			// 
			// MsgBoxDetailsForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(859, 487);
			Controls.Add(textBox);
			Name = "MsgBoxDetailsForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "MsgBoxDetailsForm";
			Load += MsgBoxDetailsFormLoad;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox;
	}
}