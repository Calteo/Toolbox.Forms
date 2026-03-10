using System.Security.Cryptography;

namespace Toolbox.Forms
{
	/// <summary>
	/// Better message box
	/// </summary>
	/// <remarks>
	/// Use the static methods to simply replace MessageBox.Show() with MsgBox.Show() and you will get a better message box. 
	/// The MsgBox class provides a more modern and customizable message box that can be used in place of the standard MessageBox class. 
	/// For full control create an instance of MsgBox and set the properties as needed before showing it.
	/// </remarks>
	public class MsgBox
	{
		/// <summary>
		/// Creates a new instance of the <see cref="MsgBox" /> class. 
		/// This constructor does not display the message box. 
		/// You can set the properties of the MsgBox instance and then call the Show() method to display it.
		/// </summary>
		public MsgBox()
		{			
		}

		/// <summary>
		/// Caption of the message box. This is the text that will appear in the title bar of the message box window. You can set this property to provide a title or context for the message being displayed.
		/// </summary>
		/// <remarks>
		/// The caption is always prefixed by the text of the form of the owner window if available, otherwise the caption of the application.
		/// </remarks>
		public string? Caption { get; set; } = "";
		/// <summary>
		/// Text of the message box. This is the main content that will be displayed to the user. You can set this property to provide information, ask a question, or display any message you want to convey.
		/// </summary>
		public string Text { get; set; } = "";

		/// <summary>
		/// Buttons to display in the message box. This property determines which buttons will be shown to the user, such as OK, Cancel, Yes, No, etc. You can set this property to specify the desired button configuration for your message box.
		/// </summary>
		public MessageBoxButtons Buttons { get; set; } = MessageBoxButtons.OK;

		/// <summary>
		/// Gets or sets the icon displayed in the message box.
		/// </summary>
		/// <remarks>This property allows customization of the message box icon, which can enhance the visual
		/// representation of the message being conveyed. Common values include information, warning, error, and question
		/// icons.</remarks>
		public MessageBoxIcon Icon { get; set; } = MessageBoxIcon.None;

		/// <summary>
		/// Gets or sets the additional details associated with the message.
		/// </summary>
		/// <remarks>This property can hold any supplementary information that provides context or clarification about
		/// the message. It may be null if no details are provided.</remarks>
		public string? Details { get; set; }

		/// <summary>
		/// Shows the message box with the specified owner. 
		/// The Show method displays the message box as a modal dialog box, which means that the user must interact with the message box before they can return to the parent window. The owner parameter specifies the window that will own the message box. 
		/// If owner is null, the message box will be displayed without an owner window.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public DialogResult Show(IWin32Window? owner)
		{
			var form = new MsgBoxForm();

			if (owner == null)
			{
				form.StartPosition = FormStartPosition.CenterScreen;
			}

			form.MsgBox = this;

			return form.ShowDialog(owner);
		}

		/// <summary>
		/// Show a general message box with the specified text, caption, buttons, and icon. The owner parameter specifies the window that will own the message box. If owner is null, the message box will be displayed without an owner window.
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <param name="details"></param>
		/// <returns></returns>
		public static DialogResult Show(IWin32Window? owner, string text, string? caption, MessageBoxButtons buttons, MessageBoxIcon icon, string? details = null)
		{
			var msgbox = new MsgBox
			{
				Caption = caption,
				Text = text,
				Buttons = buttons,
				Icon = icon,
				Details = details
			};
			
			return msgbox.Show(owner);
		}
		
		/// <summary>
		/// Show message box.
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="text"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		/// <returns></returns>
		public static DialogResult Show(IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return Show(owner, text, null, buttons, icon);
		}
	}
}
