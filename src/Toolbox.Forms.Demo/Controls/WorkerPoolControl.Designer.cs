namespace Toolbox.Forms.Demo.Controls
{
	partial class WorkerPoolControl
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
			components = new System.ComponentModel.Container();
			workerPool = new WorkerPool(components);
			buttonWait = new Button();
			layoutPanel = new TableLayoutPanel();
			labelRunning = new Label();
			textBoxProtocol = new TextBox();
			checkBoxProgress = new CheckBox();
			buttonWaitWihtInput = new Button();
			upDownCount = new NumericUpDown();
			buttonCancel = new Button();
			layoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)upDownCount).BeginInit();
			SuspendLayout();
			// 
			// workerPool
			// 
			workerPool.Owner = this;
			workerPool.Started += WorkerPoolStarted;
			workerPool.Stopped += WorkerPoolStopped;
			workerPool.ItemStarted += WorkerPoolItemStarted;
			workerPool.ItemStopped += WorkerPoolItemStopped;
			// 
			// buttonWait
			// 
			buttonWait.Dock = DockStyle.Fill;
			buttonWait.Location = new Point(869, 433);
			buttonWait.Name = "buttonWait";
			buttonWait.Size = new Size(154, 36);
			buttonWait.TabIndex = 0;
			buttonWait.Text = "Wait";
			buttonWait.UseVisualStyleBackColor = true;
			buttonWait.Click += ButtonWaitClick;
			// 
			// layoutPanel
			// 
			layoutPanel.ColumnCount = 3;
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.Controls.Add(buttonWait, 2, 3);
			layoutPanel.Controls.Add(labelRunning, 0, 3);
			layoutPanel.Controls.Add(textBoxProtocol, 0, 0);
			layoutPanel.Controls.Add(checkBoxProgress, 2, 1);
			layoutPanel.Controls.Add(buttonWaitWihtInput, 2, 2);
			layoutPanel.Controls.Add(upDownCount, 0, 2);
			layoutPanel.Controls.Add(buttonCancel, 1, 3);
			layoutPanel.Dock = DockStyle.Fill;
			layoutPanel.Location = new Point(0, 0);
			layoutPanel.Name = "layoutPanel";
			layoutPanel.RowCount = 4;
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
			layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
			layoutPanel.Size = new Size(1026, 472);
			layoutPanel.TabIndex = 0;
			// 
			// labelRunning
			// 
			labelRunning.Dock = DockStyle.Fill;
			labelRunning.Location = new Point(3, 430);
			labelRunning.Name = "labelRunning";
			labelRunning.Size = new Size(700, 42);
			labelRunning.TabIndex = 2;
			labelRunning.Text = "Stopped";
			labelRunning.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// textBoxProtocol
			// 
			layoutPanel.SetColumnSpan(textBoxProtocol, 3);
			textBoxProtocol.Dock = DockStyle.Fill;
			textBoxProtocol.Font = new Font("Consolas", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			textBoxProtocol.Location = new Point(3, 3);
			textBoxProtocol.MaxLength = 100000;
			textBoxProtocol.Multiline = true;
			textBoxProtocol.Name = "textBoxProtocol";
			textBoxProtocol.ReadOnly = true;
			textBoxProtocol.ScrollBars = ScrollBars.Both;
			textBoxProtocol.Size = new Size(1020, 340);
			textBoxProtocol.TabIndex = 3;
			textBoxProtocol.WordWrap = false;
			// 
			// checkBoxProgress
			// 
			checkBoxProgress.AutoSize = true;
			checkBoxProgress.Dock = DockStyle.Fill;
			checkBoxProgress.Location = new Point(869, 349);
			checkBoxProgress.Name = "checkBoxProgress";
			checkBoxProgress.Size = new Size(154, 36);
			checkBoxProgress.TabIndex = 4;
			checkBoxProgress.Text = "With Progress";
			checkBoxProgress.UseVisualStyleBackColor = true;
			// 
			// buttonWaitWihtInput
			// 
			buttonWaitWihtInput.Dock = DockStyle.Fill;
			buttonWaitWihtInput.Location = new Point(869, 391);
			buttonWaitWihtInput.Name = "buttonWaitWihtInput";
			buttonWaitWihtInput.Size = new Size(154, 36);
			buttonWaitWihtInput.TabIndex = 5;
			buttonWaitWihtInput.Text = "Wait with input";
			buttonWaitWihtInput.UseVisualStyleBackColor = true;
			buttonWaitWihtInput.Click += ButtonWaitWihtInputClick;
			// 
			// upDownCount
			// 
			upDownCount.Location = new Point(3, 391);
			upDownCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			upDownCount.Name = "upDownCount";
			upDownCount.Size = new Size(150, 27);
			upDownCount.TabIndex = 6;
			upDownCount.TextAlign = HorizontalAlignment.Center;
			upDownCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// buttonCancel
			// 
			buttonCancel.Dock = DockStyle.Fill;
			buttonCancel.Enabled = false;
			buttonCancel.Location = new Point(709, 433);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(154, 36);
			buttonCancel.TabIndex = 7;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancelClick;
			// 
			// WorkerPoolControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(layoutPanel);
			Name = "WorkerPoolControl";
			Size = new Size(1026, 472);
			layoutPanel.ResumeLayout(false);
			layoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)upDownCount).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private WorkerPool workerPool;
		private TableLayoutPanel layoutPanel;
		private Button buttonWait;
		private Label labelRunning;
		private TextBox textBoxProtocol;
		private CheckBox checkBoxProgress;
		private Button buttonWaitWihtInput;
		private NumericUpDown upDownCount;
		private Button buttonCancel;
	}
}
