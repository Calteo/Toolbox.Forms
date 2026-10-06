namespace Toolbox.Forms.Demo.Controls
{
	partial class ObjectListViewControl
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
			splitContainer = new SplitContainer();
			objectListView = new ObjectListView();
			groupBox1 = new GroupBox();
			buttonAdd = new Button();
			((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
			splitContainer.Panel1.SuspendLayout();
			splitContainer.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer
			// 
			splitContainer.Dock = DockStyle.Fill;
			splitContainer.FixedPanel = FixedPanel.Panel2;
			splitContainer.Location = new Point(0, 0);
			splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			splitContainer.Panel1.Controls.Add(objectListView);
			splitContainer.Size = new Size(1351, 669);
			splitContainer.SplitterDistance = 1070;
			splitContainer.TabIndex = 2;
			// 
			// objectListView
			// 
			objectListView.DataSource = null;
			objectListView.Dock = DockStyle.Fill;
			objectListView.Location = new Point(0, 0);
			objectListView.Name = "objectListView";
			objectListView.Size = new Size(1070, 669);
			objectListView.TabIndex = 0;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(buttonAdd);
			groupBox1.Dock = DockStyle.Bottom;
			groupBox1.Location = new Point(0, 544);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(1351, 125);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Options";
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(59, 44);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(94, 29);
			buttonAdd.TabIndex = 0;
			buttonAdd.Text = "Add";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += ButtonAddClick;
			// 
			// ObjectListViewControl
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(groupBox1);
			Controls.Add(splitContainer);
			Name = "ObjectListViewControl";
			Size = new Size(1351, 669);
			splitContainer.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
			splitContainer.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer;
		private GroupBox groupBox1;
		private ObjectListView objectListView;
		private Button buttonAdd;
	}
}
