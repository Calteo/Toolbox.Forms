namespace Toolbox.Forms.Demo
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tabControl = new TabControl();
			tabPageMesgBox = new TabPage();
			msgBoxControl = new Toolbox.Forms.Demo.Controls.MsgBoxControl();
			tabControl.SuspendLayout();
			tabPageMesgBox.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl
			// 
			tabControl.Controls.Add(tabPageMesgBox);
			tabControl.Dock = DockStyle.Fill;
			tabControl.Location = new Point(0, 0);
			tabControl.Margin = new Padding(4);
			tabControl.Name = "tabControl";
			tabControl.SelectedIndex = 0;
			tabControl.Size = new Size(1462, 652);
			tabControl.TabIndex = 0;
			// 
			// tabPageMesgBox
			// 
			tabPageMesgBox.Controls.Add(msgBoxControl);
			tabPageMesgBox.Location = new Point(4, 34);
			tabPageMesgBox.Margin = new Padding(4);
			tabPageMesgBox.Name = "tabPageMesgBox";
			tabPageMesgBox.Padding = new Padding(4);
			tabPageMesgBox.Size = new Size(1454, 614);
			tabPageMesgBox.TabIndex = 1;
			tabPageMesgBox.Text = "MsgBox";
			tabPageMesgBox.UseVisualStyleBackColor = true;
			// 
			// msgBoxControl
			// 
			msgBoxControl.Dock = DockStyle.Fill;
			msgBoxControl.Location = new Point(4, 4);
			msgBoxControl.Name = "msgBoxControl";
			msgBoxControl.Size = new Size(1446, 606);
			msgBoxControl.TabIndex = 0;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1462, 652);
			Controls.Add(tabControl);
			Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Margin = new Padding(4);
			Name = "MainForm";
			Text = "Toolbox.Forms - Demo";
			tabControl.ResumeLayout(false);
			tabPageMesgBox.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl;
		private TabPage tabPageMesgBox;
		private Controls.MsgBoxControl msgBoxControl;
	}
}
