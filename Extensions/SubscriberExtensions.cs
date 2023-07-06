using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using PEPEngineers.PEPEvents.Implementation;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Extensions
{
	public static class SubscriberExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Publish<T>([NotNull] this IBroker broker, T message)
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			EventsManager.Instance.Publish(message, broker);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>([NotNull] this IBroker broker, ISubscriber item, Action<TMessage> action)
			
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			broker.Subscribe(new ActionSubscriber<TMessage>(item, action));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this IBroker<TMessage> broker, ISubscriber item, Action<TMessage> action)
			
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			broker.Subscribe(new ActionSubscriber<TMessage>(item, action));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber)
			
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
			EventsManager.Instance.Subscribe(broker, subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Subscribe<TMessage>(this IBroker<TMessage> broker, ISubscriber<TMessage> subscriber)
			
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
			EventsManager.Instance.Subscribe(broker, subscriber);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Unsubscribe<TMessage>(this ISubscriber<TMessage> subscriber, IBroker broker)
			
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
			EventsManager.Instance.Unsubscribe(broker, subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Unsubscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber)
			
		{
			Unsubscribe(subscriber, broker);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UnsubscribeAll(this ISubscriber subscriber)
		{
			if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
			EventsManager.Instance.UnsubscribeAll(subscriber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Flush(this IBroker broker)
		{
			if (broker == null) throw new ArgumentNullException(nameof(broker));
			EventsManager.Instance.UnsubscribeAll(broker);
		}
	}
}