namespace Toolbox.Forms.Demo.Controls
{
	partial class MsgBoxControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			layoutPanel = new TableLayoutPanel();
			buttonShow = new Button();
			checkBoxNoOwner = new CheckBox();
			textBoxText = new TextBox();
			comboBoxButtons = new ComboBox();
			labelResultValue = new Label();
			comboBoxIcons = new ComboBox();
			textBoxDetails = new TextBox();
			layoutPanel.SuspendLayout();
			SuspendLayout();
			// 
			// layoutPanel
			// 
			layoutPanel.ColumnCount = 3;
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.Controls.Add(buttonShow, 2, 4);
			layoutPanel.Controls.Add(checkBoxNoOwner, 2, 2);
			layoutPanel.Controls.Add(textBoxText, 1, 0);
			layoutPanel.Controls.Add(comboBoxButtons, 1, 2);
			layoutPanel.Controls.Add(labelResultValue, 1, 4);
			layoutPanel.Controls.Add(comboBoxIcons, 1, 1);
			layoutPanel.Controls.Add(textBoxDetails, 1, 3);
			layoutPanel.Dock = DockStyle.Fill;
			layoutPanel.Location = new Point(0, 0);
			layoutPanel.Name = "layoutPanel";
			layoutPanel.RowCount = 5;
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
			layoutPanel.Size = new Size(924, 515);
			layoutPanel.TabIndex = 0;
			// 
			// buttonShow
			// 
			buttonShow.Dock = DockStyle.Fill;
			buttonShow.Location = new Point(767, 475);
			buttonShow.Name = "buttonShow";
			buttonShow.Size = new Size(154, 37);
			buttonShow.TabIndex = 0;
			buttonShow.Text = "Show";
			buttonShow.UseVisualStyleBackColor = true;
			buttonShow.Click += ButtonShowClick;
			// 
			// checkBoxNoOwner
			// 
			checkBoxNoOwner.AutoSize = true;
			checkBoxNoOwner.Dock = DockStyle.Fill;
			checkBoxNoOwner.Location = new Point(767, 239);
			checkBoxNoOwner.Name = "checkBoxNoOwner";
			checkBoxNoOwner.Size = new Size(154, 36);
			checkBoxNoOwner.TabIndex = 2;
			checkBoxNoOwner.Text = "No Owner";
			checkBoxNoOwner.UseVisualStyleBackColor = true;
			// 
			// textBoxText
			// 
			textBoxText.Dock = DockStyle.Fill;
			textBoxText.Location = new Point(123, 3);
			textBoxText.Multiline = true;
			textBoxText.Name = "textBoxText";
			textBoxText.ScrollBars = ScrollBars.Both;
			textBoxText.Size = new Size(638, 188);
			textBoxText.TabIndex = 3;
			textBoxText.Text = "Some message.\r\nMutiple line with some longer text.";
			textBoxText.WordWrap = false;
			// 
			// comboBoxButtons
			// 
			comboBoxButtons.Dock = DockStyle.Fill;
			comboBoxButtons.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxButtons.FormattingEnabled = true;
			comboBoxButtons.Location = new Point(123, 239);
			comboBoxButtons.Name = "comboBoxButtons";
			comboBoxButtons.Size = new Size(638, 28);
			comboBoxButtons.Sorted = true;
			comboBoxButtons.TabIndex = 4;
			// 
			// labelResultValue
			// 
			labelResultValue.Dock = DockStyle.Fill;
			labelResultValue.Location = new Point(123, 472);
			labelResultValue.Name = "labelResultValue";
			labelResultValue.Size = new Size(638, 43);
			labelResultValue.TabIndex = 5;
			labelResultValue.Text = "<result>";
			labelResultValue.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// comboBoxIcons
			// 
			comboBoxIcons.Dock = DockStyle.Fill;
			comboBoxIcons.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxIcons.FormattingEnabled = true;
			comboBoxIcons.Location = new Point(123, 197);
			comboBoxIcons.Name = "comboBoxIcons";
			comboBoxIcons.Size = new Size(638, 28);
			comboBoxIcons.Sorted = true;
			comboBoxIcons.TabIndex = 6;
			// 
			// textBoxDetails
			// 
			textBoxDetails.Dock = DockStyle.Fill;
			textBoxDetails.Location = new Point(123, 281);
			textBoxDetails.Multiline = true;
			textBoxDetails.Name = "textBoxDetails";
			textBoxDetails.ScrollBars = ScrollBars.Both;
			textBoxDetails.Size = new Size(638, 188);
			textBoxDetails.TabIndex = 7;
			// 
			// MsgBoxControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(layoutPanel);
			Name = "MsgBoxControl";
			Size = new Size(924, 515);
			layoutPanel.ResumeLayout(false);
			layoutPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel layoutPanel;
		private Button buttonShow;
		private CheckBox checkBoxNoOwner;
		private TextBox textBoxText;
		private ComboBox comboBoxButtons;
		private Label labelResultValue;
		private ComboBox comboBoxIcons;
		private TextBox textBoxDetails;
	}
}
