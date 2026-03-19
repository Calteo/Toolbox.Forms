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
			upDownCycles = new NumericUpDown();
			buttonCancel = new Button();
			labelCycles = new Label();
			labelTasks = new Label();
			upDownTasks = new NumericUpDown();
			comboBoxClosing = new ComboBox();
			upDownWait = new NumericUpDown();
			layoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)upDownCycles).BeginInit();
			((System.ComponentModel.ISupportInitialize)upDownTasks).BeginInit();
			((System.ComponentModel.ISupportInitialize)upDownWait).BeginInit();
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
			layoutPanel.ColumnCount = 7;
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
			layoutPanel.Controls.Add(buttonWait, 6, 3);
			layoutPanel.Controls.Add(labelRunning, 3, 3);
			layoutPanel.Controls.Add(textBoxProtocol, 0, 0);
			layoutPanel.Controls.Add(checkBoxProgress, 6, 1);
			layoutPanel.Controls.Add(buttonWaitWihtInput, 6, 2);
			layoutPanel.Controls.Add(upDownCycles, 3, 2);
			layoutPanel.Controls.Add(buttonCancel, 5, 3);
			layoutPanel.Controls.Add(labelCycles, 2, 2);
			layoutPanel.Controls.Add(labelTasks, 0, 2);
			layoutPanel.Controls.Add(upDownTasks, 1, 2);
			layoutPanel.Controls.Add(comboBoxClosing, 5, 2);
			layoutPanel.Controls.Add(upDownWait, 1, 3);
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
			layoutPanel.SetColumnSpan(labelRunning, 2);
			labelRunning.Dock = DockStyle.Fill;
			labelRunning.Location = new Point(483, 430);
			labelRunning.Name = "labelRunning";
			labelRunning.Size = new Size(220, 42);
			labelRunning.TabIndex = 2;
			labelRunning.Text = "Stopped";
			labelRunning.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// textBoxProtocol
			// 
			layoutPanel.SetColumnSpan(textBoxProtocol, 7);
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
			checkBoxProgress.Text = "With progress";
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
			// upDownCycles
			// 
			upDownCycles.Dock = DockStyle.Fill;
			upDownCycles.Location = new Point(483, 391);
			upDownCycles.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			upDownCycles.Name = "upDownCycles";
			upDownCycles.Size = new Size(154, 27);
			upDownCycles.TabIndex = 6;
			upDownCycles.TextAlign = HorizontalAlignment.Center;
			upDownCycles.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
			// labelCycles
			// 
			labelCycles.AutoSize = true;
			labelCycles.Dock = DockStyle.Fill;
			labelCycles.Location = new Point(323, 388);
			labelCycles.Name = "labelCycles";
			labelCycles.Size = new Size(154, 42);
			labelCycles.TabIndex = 8;
			labelCycles.Text = "Cylcles";
			labelCycles.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// labelTasks
			// 
			labelTasks.Dock = DockStyle.Fill;
			labelTasks.Location = new Point(3, 388);
			labelTasks.Name = "labelTasks";
			labelTasks.Size = new Size(154, 42);
			labelTasks.TabIndex = 9;
			labelTasks.Text = "Tasks";
			labelTasks.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// upDownTasks
			// 
			upDownTasks.Dock = DockStyle.Fill;
			upDownTasks.Location = new Point(163, 391);
			upDownTasks.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			upDownTasks.Name = "upDownTasks";
			upDownTasks.Size = new Size(154, 27);
			upDownTasks.TabIndex = 10;
			upDownTasks.TextAlign = HorizontalAlignment.Center;
			upDownTasks.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// comboBoxClosing
			// 
			comboBoxClosing.Dock = DockStyle.Fill;
			comboBoxClosing.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxClosing.FormattingEnabled = true;
			comboBoxClosing.Location = new Point(709, 391);
			comboBoxClosing.Name = "comboBoxClosing";
			comboBoxClosing.Size = new Size(154, 28);
			comboBoxClosing.TabIndex = 11;
			comboBoxClosing.SelectedIndexChanged += ComboBoxClosingSelectedIndexChanged;
			// 
			// upDownWait
			// 
			upDownWait.Dock = DockStyle.Fill;
			upDownWait.Increment = new decimal(new int[] { 100, 0, 0, 0 });
			upDownWait.Location = new Point(163, 433);
			upDownWait.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			upDownWait.Name = "upDownWait";
			upDownWait.Size = new Size(154, 27);
			upDownWait.TabIndex = 12;
			upDownWait.TextAlign = HorizontalAlignment.Center;
			upDownWait.ThousandsSeparator = true;
			upDownWait.Value = new decimal(new int[] { 500, 0, 0, 0 });
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
			((System.ComponentModel.ISupportInitialize)upDownCycles).EndInit();
			((System.ComponentModel.ISupportInitialize)upDownTasks).EndInit();
			((System.ComponentModel.ISupportInitialize)upDownWait).EndInit();
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
		private NumericUpDown upDownCycles;
		private Button buttonCancel;
		private Label labelCycles;
		private Label labelTasks;
		private NumericUpDown upDownTasks;
		private ComboBox comboBoxClosing;
		private NumericUpDown upDownWait;
	}
}
