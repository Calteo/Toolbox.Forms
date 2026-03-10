using System.ComponentModel;
using System.Text;
using Toolbox.Collection.Generics;

namespace Toolbox.Forms
{
	internal partial class MsgBoxForm : Form
	{
		public MsgBoxForm()
		{
			InitializeComponent();
		}

		private MsgBox _msgBox = new();

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public MsgBox MsgBox
		{
			get => _msgBox;
			set
			{
				_msgBox = value;
				CalculateLayout();
			}
		}

		private Button[]? _buttons;
		private Button[] Buttons => _buttons ??= [button1, button2, button3, button4];
		private void MsgBoxFormLoad(object sender, EventArgs e)
		{
			Text = Owner?.ParentForm?.Text ?? Application.ProductName;

			if (MsgBox.Caption != null && MsgBox.Caption != "")
			{
				Text += " - " + MsgBox.Caption;
			}

			Font = Owner?.Font != null
				? Owner.Font
				: SystemFonts.MessageBoxFont;

			if (!pictureBox.Enabled) pictureBox.Visible = false;
			ControlBox = CancelButton != null;
		}

		private Button[] CreateButtons()
		{
			foreach (var button in Buttons)
			{
				button.Enabled = false;
			}

			switch (MsgBox.Buttons)
			{
				case MessageBoxButtons.OK:
					AcceptButton = SetButton("&OK", DialogResult.OK);
					break;
				case MessageBoxButtons.OKCancel:
					AcceptButton = SetButton("&OK", DialogResult.OK);
					CancelButton = SetButton("&Cancel", DialogResult.Cancel);
					break;
				case MessageBoxButtons.YesNo:
					AcceptButton = SetButton("&Yes", DialogResult.Yes);
					CancelButton = SetButton("No", DialogResult.No);
					break;
				case MessageBoxButtons.YesNoCancel:
					AcceptButton = SetButton("&Yes", DialogResult.Yes);
					SetButton("No", DialogResult.No);
					CancelButton = SetButton("&Cancel", DialogResult.Cancel);
					break;
				case MessageBoxButtons.CancelTryContinue:
					SetButton("&Cancel", DialogResult.Cancel);
					SetButton("Retry", DialogResult.Retry);
					AcceptButton = SetButton("&Continue", DialogResult.Ignore);
					break;
				case MessageBoxButtons.RetryCancel:
					SetButton("&Retry", DialogResult.Retry);
					CancelButton = SetButton("&Cancel", DialogResult.Cancel);
					break;
				case MessageBoxButtons.AbortRetryIgnore:
					SetButton("&Abort", DialogResult.Abort);
					SetButton("&Retry", DialogResult.Retry);
					AcceptButton = SetButton("&Ignore", DialogResult.Ignore);
					break;
				default:
					throw new NotSupportedException("Unsupported button configuration: " + MsgBox.Buttons);
			}

			if (!string.IsNullOrEmpty(MsgBox.Details))
			{
				var detailsButton = SetButton("&Details", DialogResult.None);
				detailsButton.Click += DetailsButtonClick;
			}

			var enabledButtons = Buttons.Where(b => b.Enabled).ToArray();

			var maxSize = enabledButtons.Aggregate(Size.Empty, (s, b) =>
			{
				return new Size(Math.Max(s.Width, b.Width), Math.Max(s.Height, b.Height));
			});

			foreach (var button in enabledButtons)
			{
				button.AutoSize = false;
				button.Size = maxSize;
			}

			return enabledButtons;
		}

		private void DetailsButtonClick(object? sender, EventArgs e)
		{
			var detailsForm = new MsgBoxDetailsForm
			{
				Text = Text + " - Details",
				DetailsText = MsgBox.Details!,
				Font = Font,				
			};

			detailsForm.ShowDialog(this);
		}

		private void CalculateLayout()
		{
			const int dy = 5;
			const int dx = 10;
			const int dxIcon = 5;
			const int dxButtons = 10;
			const int dyButtons = 10;

			CreateIcon();

			var buttons = CreateButtons();

			CreateText();

			var buttonWidth = buttons[0].Width;
			var buttonHeight = buttons[0].Height;
			var buttonsWidth = buttons.Length * buttonWidth + (buttons.Length - 1) * dxButtons;

			var topHeight = Math.Max(pictureBox.Height, labelText.Height);
			var topWidth = labelText.Width + (pictureBox.Enabled ? pictureBox.Width + dxIcon : 0);

			var formWidth = dx + Math.Max(topWidth, buttonsWidth) + dx;
			var formHeight = dy + topHeight + dyButtons + buttonHeight + dy;

			if (!pictureBox.Enabled)
			{
				labelText.Left = dx;
			}
			else
			{
				pictureBox.Left = dx;
				labelText.Left = pictureBox.Right + dxIcon;
			}

			pictureBox.Top = labelText.Top = dy;

			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].Left = (formWidth - buttonsWidth) / 2 + i * (buttonWidth + dxButtons);
				buttons[i].Top = dy + topHeight + dyButtons;
			}

			ClientSize = new Size(formWidth, formHeight);
		}

		private void CreateText()
		{
			labelText.Text = MsgBox.Text;

			var screen = Screen.FromControl(this);

			var textSize = TextRenderer.MeasureText(MsgBox.Text, Font, new Size(screen.WorkingArea.Width / 2, 0), TextFormatFlags.WordBreak);
			labelText.ClientSize = textSize;
		}

		private void CreateIcon()
		{
			if (MsgBox.Icon == MessageBoxIcon.None)
			{
				pictureBox.Enabled = false;
				labelText.Left = pictureBox.Left;

				return;
			}

			pictureBox.Enabled = true;
			pictureBox.Image = MsgBox.Icon switch
			{
				MessageBoxIcon.Error => SystemIcons.Error.ToBitmap(),
				MessageBoxIcon.Information => SystemIcons.Information.ToBitmap(),
				MessageBoxIcon.Warning => SystemIcons.Warning.ToBitmap(),
				MessageBoxIcon.Question => SystemIcons.Question.ToBitmap(),
				_ => throw new NotSupportedException("Unsupported icon: " + MsgBox.Icon)
			};

			pictureBox.ClientSize = pictureBox.Image.Size;
		}

		private Button SetButton(string text, DialogResult result)
		{
			var button = Buttons.First(b => !b.Enabled);

			button.Text = text;
			button.DialogResult = result;
			button.Enabled = true;

			return button;
		}

		private void MenuItemCopyTextClick(object sender, EventArgs e)
		{
			var builder = new StringBuilder();	

			builder.AppendLine("Caption: " + Text);
			builder.AppendLine("Icon: " + MsgBox.Icon);
			builder.AppendLine("Buttons: " + MsgBox.Buttons);
			builder.AppendLine("Message:");
			builder.AppendLine(MsgBox.Text);

			Clipboard.SetText(builder.ToString());
		}
	}
}
