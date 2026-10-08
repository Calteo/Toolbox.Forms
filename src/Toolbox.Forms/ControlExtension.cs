using System.Reflection;

namespace Toolbox.Forms
{
	/// <summary>
	/// Extension methods for <see cref="Control"/>.
	/// </summary>
	public static class ControlExtension
	{
		/// <summary>
		/// Subscribes to an event on a source object and ensures that the event handler is invoked on the UI thread of the specified control.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="source"></param>
		/// <param name="eventName"></param>
		/// <param name="handler"></param>
		/// <exception cref="ArgumentException"></exception>
		/// <remarks>
		/// The event handler will be automatically unsubscribed when the control is disposed.
		/// The event handler will not invoked if the control is disposed or in the process of disposing. 
		/// This ensures that event handling does not occur on a disposed control, preventing potential exceptions and undefined behavior.
		/// If the event source is already active and the event is raised before the subscription is complete, 
		/// the handler may not be invoked for that event. It is recommended to subscribe to events before the source object becomes active
		/// of the control is finished initializing to ensure that all events are captured.
		/// </remarks>
		public static void Subscribe(
			this Control control,
			object source,
			string eventName,
			Delegate handler)
		{
			ArgumentNullException.ThrowIfNull(control);
			ArgumentNullException.ThrowIfNull(source);
			ArgumentNullException.ThrowIfNull(eventName);
			ArgumentNullException.ThrowIfNull(handler);

			EventInfo eventInfo = source.GetType().GetEvent(
				eventName,
				BindingFlags.Instance | BindingFlags.Public)
				?? throw new ArgumentException($"Event '{eventName}' not found on {source.GetType().Name}.",nameof(eventName));

			if (eventInfo.EventHandlerType is null)
				throw new ArgumentException($"Event '{eventName}' has no handler type.", nameof(eventName));

			var invokeMethod = eventInfo.EventHandlerType.GetMethod("Invoke")!;
			var parameters = invokeMethod.GetParameters();

			if (parameters.Length != 2)
				throw new ArgumentException("The event must have a two-parameter handler.", nameof(eventName));

			// Create a delegate with the event's exact signature.
			var wrapper = CreateWrapper(
				eventInfo.EventHandlerType,
				control,
				handler);

			eventInfo.AddEventHandler(source, wrapper);

			EventHandler cleanup = null!;
			cleanup = (_, _) =>
			{
				eventInfo.RemoveEventHandler(source, wrapper);
				control.Disposed -= cleanup;
			};
						control.Disposed += cleanup;
		}

		private static Delegate CreateWrapper(
			Type delegateType,
			Control control,
			Delegate handler)
		{
			var invokeMethod = delegateType.GetMethod("Invoke")!;

			var parameters = invokeMethod.GetParameters();

			var sender = System.Linq.Expressions.Expression.Parameter(parameters[0].ParameterType, "sender");
			var args = System.Linq.Expressions.Expression.Parameter(parameters[1].ParameterType, "args");

			var body = System.Linq.Expressions.Expression.Call(
				typeof(ControlExtension),
				nameof(Dispatch),
				Type.EmptyTypes,
				System.Linq.Expressions.Expression.Constant(control),
				System.Linq.Expressions.Expression.Constant(handler),
				System.Linq.Expressions.Expression.Convert(sender, typeof(object)),
				System.Linq.Expressions.Expression.Convert(args, typeof(object)));

			return System.Linq.Expressions.Expression.Lambda(delegateType, body, sender, args).Compile();
		}

		private static void Dispatch(
			Control control,
			Delegate handler,
			object? sender,
			object? args)
		{
			if (control.IsDisposed || control.Disposing)
				return;

			void InvokeHandler()
			{
				if (control.IsDisposed || control.Disposing)
					return;

				handler.DynamicInvoke(sender, args);
			}

			if (control.InvokeRequired)
			{
				try
				{
					control.BeginInvoke((Action)InvokeHandler);
				}
				catch (InvalidOperationException)
				{
					// Handle is unavailable or being destroyed.
				}
			}
			else
			{
				InvokeHandler();
			}
		}
	}
}
