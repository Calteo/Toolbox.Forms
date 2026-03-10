namespace Toolbox.Forms
{
	partial class MsgBoxForm
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
			components = new System.ComponentModel.Container();
			labelText = new Label();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			pictureBox = new PictureBox();
			contextMenuStrip = new ContextMenuStrip(components);
			menuItemCopyText = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			contextMenuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// labelText
			// 
			labelText.Location = new Point(163, 9);
			labelText.Name = "labelText";
			labelText.Size = new Size(679, 150);
			labelText.TabIndex = 1;
			labelText.Text = "label1";
			// 
			// button1
			// 
			button1.AutoSize = true;
			button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button1.Location = new Point(36, 249);
			button1.Name = "button1";
			button1.Size = new Size(71, 30);
			button1.TabIndex = 1;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.AutoSize = true;
			button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button2.Location = new Point(163, 249);
			button2.Name = "button2";
			button2.Size = new Size(71, 30);
			button2.TabIndex = 2;
			button2.Text = "button2";
			button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			button3.AutoSize = true;
			button3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button3.Location = new Point(290, 249);
			button3.Name = "button3";
			button3.Size = new Size(71, 30);
			button3.TabIndex = 3;
			button3.Text = "button3";
			button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			button4.AutoSize = true;
			button4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			button4.Location = new Point(411, 249);
			button4.Name = "button4";
			button4.Size = new Size(71, 30);
			button4.TabIndex = 4;
			button4.Text = "button4";
			button4.UseVisualStyleBackColor = true;
			// 
			// pictureBox
			// 
			pictureBox.Location = new Point(12, 9);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(125, 62);
			pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
			pictureBox.TabIndex = 5;
			pictureBox.TabStop = false;
			// 
			// contextMenuStrip
			// 
			contextMenuStrip.ImageScalingSize = new Size(20, 20);
			contextMenuStrip.Items.AddRange(new ToolStripItem[] { menuItemCopyText });
			contextMenuStrip.Name = "contextMenuStrip";
			contextMenuStrip.Size = new Size(113, 28);
			// 
			// menuItemCopyText
			// 
			menuItemCopyText.Name = "menuItemCopyText";
			menuItemCopyText.Size = new Size(112, 24);
			menuItemCopyText.Text = "Copy";
			menuItemCopyText.ToolTipText = "Copies the message to the clipboard.";
			menuItemCopyText.Click += MenuItemCopyTextClick;
			// 
			// MsgBoxForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(924, 295);
			ContextMenuStrip = contextMenuStrip;
			ControlBox = false;
			Controls.Add(pictureBox);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(labelText);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MsgBoxForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "MsgBoxForm";
			Load += MsgBoxFormLoad;
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			contextMenuStrip.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label labelText;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private PictureBox pictureBox;
		private ContextMenuStrip contextMenuStrip;
		private ToolStripMenuItem menuItemCopyText;
	}
}