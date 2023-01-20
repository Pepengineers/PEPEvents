using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PEPEvents.Extensions;
using PEPEvents.Interface;

namespace PEPEvents.Implementation
{
	internal static class MessagePipe<TMessage> where TMessage : struct, IMessage
	{
		private static readonly SubscriptionFactory<TMessage> Subscription = new();

		private static readonly Dictionary<IBroker, List<ISubscriber<TMessage>>> Listeners =
			new();

		internal static Type MessageType { get; } = typeof(TMessage);

		internal static IDisposable Subscribe(IBroker broker, ISubscriber<TMessage> subscriber)
		{
			if (broker == null)
				throw new ArgumentNullException(nameof(broker));

			if (subscriber == null)
				throw new ArgumentNullException(nameof(subscriber));

#if UNITY_EDITOR || DEBUG
			UnityEngine.Debug.Log(
				$"#Events# {subscriber.GetType().Name} subscribe to {MessageType.Name} in {broker.GetType().FullName}");
#endif
			if (Listeners.TryGetValue(broker, out var subscribers))
			{
				if (subscribers.Contains(subscriber) == false)
					subscribers.Add(subscriber);
			}
			else
			{
				subscribers = new List<ISubscriber<TMessage>> { subscriber };
				Listeners.Add(broker, subscribers);
			}

			return Subscription.Create(subscriber, subscribers);
		}

		internal static void Publish(TMessage msg, IBroker broker)
		{
			if (ReferenceEquals(broker, null))
				return;

#if UNITY_EDITOR || DEBUG
			UnityEngine.Debug.Log($"#Events# {broker.GetType().FullName} raise event {MessageType.Name}");
#endif

			if (Listeners.TryGetValue(broker, out var subscribers))
			{
				Publish(subscribers, msg);
			}
		}

		internal static void Remove(IBroker broker)
		{
			if (Listeners.TryGetValue(broker, out var subscribers))
				while (subscribers.Count != 0)
				{
					var subscriber = subscribers[0];
					subscriber.Unsubscribe(broker);
				}

			Listeners.Remove(broker);
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Publish(IReadOnlyList<ISubscriber<TMessage>> subscribers, TMessage message)
		{
			var count = subscribers.Count;
			for (var i = 0; i < count; i++)
			{
				var subscriber = subscribers[i];
				Publish(subscriber, message);
			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Publish(ISubscriber<TMessage> subscriber, TMessage message)
		{
			try
			{
				subscriber.OnNext(message);
			}
			catch (Exception e)
			{
				subscriber.OnError(e);
			}
		}
	}
}