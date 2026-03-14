using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Toolbox.Forms.Demo.Controls
{
	internal partial class WorkerPoolControl : UserControl
	{
		public WorkerPoolControl()
		{
			InitializeComponent();
		}

		private void WorkerPoolStarted(object sender, EventArgs e)
		{
			labelRunning.Text = "Worker pool is running...";
			WriteProtocol("Worker pool has started.");
			buttonCancel.Enabled = true;
		}

		private void WorkerPoolStopped(object sender, EventArgs e)
		{
			labelRunning.Text = "Worker pool is stopped.";
			WriteProtocol("Worker pool has stopped.");
			buttonCancel.Enabled = false;
		}

		private int _waitCount;

		private void ButtonWaitClick(object sender, EventArgs e)
		{
			if (checkBoxProgress.Checked)
			{
				workerPool.Enqueue<string>(WaitSingle, WaitSimpleProgess, WaitSimpleCompleted);
			}
			else
			{
				workerPool.Enqueue<string>(WaitSingle, WaitSimpleCompleted);
			}			
		}

		private void WaitSimpleProgess(string name, int id, string message)
		{
			WriteProtocol($"Work '{name}' making progress: [{id}] - {message}");
		}

		private void WaitSimpleCompleted(IWorkResult result)
		{
			WriteProtocol($"Work '{result.Name}' completed. Canceled: {result.Canceled}, Exception: {result.Exception?.Message ?? "<null>"}");
		}

		private void WaitSingle(IWorker<string> worker)
		{
			worker.ReportProgress(0, "Starting work...");
			Thread.Sleep(2000);
			if (worker.IsCancelled) return;
			
			worker.ReportProgress(1, "Halfway done...");
			Thread.Sleep(2000);
			if (worker.IsCancelled) return;

			worker.ReportProgress(2, "Work completed.");
		}

		private void WriteProtocol(string message)
		{
			if (textBoxProtocol.InvokeRequired)
			{
				textBoxProtocol.Invoke(new Action(() => WriteProtocol(message)));
				return;
			}
			textBoxProtocol.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
		}

		private void WorkerPoolItemStopped(object sender, WorkItemEventArgs e)
		{
			WriteProtocol($"Work item '{e.Name}' has completed.");
		}

		private void WorkerPoolItemStarted(object sender, WorkItemEventArgs e)
		{
			WriteProtocol($"Work item '{e.Name}' has started.");
		}

		private void ButtonWaitWihtInputClick(object sender, EventArgs e)
		{
			if (checkBoxProgress.Checked)
			{
				workerPool.Enqueue<int, string, string>($"WaitInputProgress#{_waitCount++}",
					WorkWithInput,
					(int)upDownCount.Value,
					WorkWithInputProgress,
					WorkWithInputCompleted);
			}
			else
			{
				workerPool.Enqueue<int, string, string>($"WaitInputProgress#{_waitCount++}",
					WorkWithInput,
					(int)upDownCount.Value,
					null,
					WorkWithInputCompleted);
			}
		}

		private string WorkWithInput(IWorker<string> worker, int input)
		{
			worker.ReportProgress(0, "before loop");
			for (int i = 0; i < input; i++)
			{
				Thread.Sleep(500);
				worker.ReportProgress(1, $"Progress: {i + 1}/{input}");
				if (worker.IsCancelled)
				{
					return "Cancelled";
				}
				if (i == 11)
					throw new NotSupportedException("Simulated exception at iteration 12.");
			}
			worker.ReportProgress(3, "after loop");

			return $"Processed input: {input}";
		}

		private void WorkWithInputProgress(string name, int id, string arg)
		{
			WriteProtocol($"Work '{name}' making progress: [{id}] - {arg}");
		}

		private void WorkWithInputCompleted(IWorkResult<int, string> result)
		{
			WriteProtocol($"Work '{result.Name}' completed. Input: {result.Input}, Output: '{result.Output}', Canceled: {result.Canceled}, Exception: {result.Exception?.Message ?? "<null>"}");
		}

		private void ButtonCancelClick(object sender, EventArgs e)
		{
			workerPool.Cancel();
		}
	}
}
