namespace Toolbox.Forms
{
	/// <summary>
	/// Specifies the available behaviors when closing the form.
	/// </summary>
	public enum ClosingBehavior
	{
		/// <summary>
		/// Do nothing, the form will be closed as normal.
		/// </summary>
		None,
		/// <summary>
		/// The operation will be canceled, the form will close when the operations stopped.
		/// </summary>
		CancelClose,
		/// <summary>
		/// The operation will be canceled, the wait coursor will be activated and the form will close when the operations stopped.
		/// </summary>
		CancelWaitClose,
		/// <summary>
		/// The operation will be canceled, the form be hidden and the form will close when the operations stopped.
		/// </summary>
		CancelHideClose,
		/// <summary>
		/// Ask the user if the form should be closed, if user accepts the worker gets cancled and the form will be closed immediately.
		/// </summary>
		QueryClose,
		/// <summary>
		/// A blocking message box will be shown, the form will not be closed.
		/// </summary>
		BlockClose
	}
}
