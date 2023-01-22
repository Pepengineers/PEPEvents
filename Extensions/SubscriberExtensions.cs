using System.Runtime.CompilerServices;
using PEPEvents.Implementation;
using PEPEvents.Interface;

namespace PEPEvents.Extensions
{
	public static class SubscriberExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Publish<T>(this IBroker broker, T message) where T : struct, IMessage
		{
			EventsManager.Instance.Publish(message, broker);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this ISubscriber<TMessage> subscriber, IBroker broker)
			where TMessage : struct, IMessage
		{
			EventsManager.Instance.Subscribe(broker, subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber)
			where TMessage : struct, IMessage
		{
			Subscribe(subscriber, broker);
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
		public static void UnsubscribeAll(this IBroker broker)
		{
			EventsManager.Instance.UnsubscribeAll(broker);
		}
	}
}