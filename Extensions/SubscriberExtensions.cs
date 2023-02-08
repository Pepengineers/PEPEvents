using System.Runtime.CompilerServices;
using PEPEngineers.PEPEvents.Implementation;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Extensions
{
	public static class SubscriberExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Publish<T>(this IBroker broker, T message) where T : struct, IMessage
		{
			EventsManager.Instance.Publish(message, broker);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber)
			where TMessage : struct, IMessage
		{
			EventsManager.Instance.Subscribe(broker, subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this IBroker<TMessage> broker, ISubscriber<TMessage> subscriber)
			where TMessage : struct, IMessage
		{
			EventsManager.Instance.Subscribe(broker, subscriber);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Unsubscribe<TMessage>(this ISubscriber<TMessage> subscriber, IBroker broker)
			where TMessage : struct, IMessage
		{
			EventsManager.Instance.Unsubscribe(broker, subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Unsubscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber)
			where TMessage : struct, IMessage
		{
			Unsubscribe(subscriber, broker);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeAll(this ISubscriber subscriber)
		{
			EventsManager.Instance.UnsubscribeAll(subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Done(this IBroker broker)
		{
			EventsManager.Instance.UnsubscribeAll(broker);
		}
	}
}