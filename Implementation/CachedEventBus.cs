using System.Collections.Generic;
using PEPEvents.Interface;

namespace PEPEvents.Implementation
{
	internal sealed class CachedEventBus : IEventBus
	{
		private readonly Dictionary<IBroker, HashSet<TargetSubscriptions>> brokerSubscriptions = new();
		private readonly Dictionary<ISubscriber, TargetSubscriptions> userSubscriptions = new();
		public IReadOnlyCollection<ISubscriptions> Subscriptions => userSubscriptions.Values;

		public void Unsubscribe<T>(IBroker broker, ISubscriber<T> subscriber) where T : struct, IMessage
		{
			if (userSubscriptions.TryGetValue(subscriber, out var subscriptions) == false) return;

			subscriptions.Remove(broker, MessagePipe<T>.MessageType);
			if (subscriptions.Count <= 0)
			{
				userSubscriptions.Remove(subscriber);
			}
		}

		public void UnsubscribeAll(ISubscriber subscriber)
		{
			if (userSubscriptions.Remove(subscriber, out var targetSubscriptions))
			{
				foreach (var broker in targetSubscriptions.Brokers)
				{
					brokerSubscriptions[broker].Remove(targetSubscriptions);
				}
				targetSubscriptions.RemoveAll();
			}
		}

		public void UnsubscribeAll(IBroker broker)
		{
			if (brokerSubscriptions.Remove(broker, out var subscriptions))
			{
				foreach (var subscription in subscriptions)
				{
					subscription.Remove(broker);
					if (subscriptions.Count <= 0) 
						userSubscriptions.Remove(subscription.Subscriber);
				}

				subscriptions.Clear();
			}
		}

		public void Subscribe<T>(IBroker broker, ISubscriber<T> subscriber) where T : struct, IMessage
		{
			if (userSubscriptions.TryGetValue(subscriber, out var targetSubscriptions) == false)
			{
				targetSubscriptions = new TargetSubscriptions(subscriber);
				userSubscriptions.Add(subscriber, targetSubscriptions);
			}

			if (brokerSubscriptions.TryGetValue(broker, out var brokerTargetSubscriptions) == false)
				brokerTargetSubscriptions = new HashSet<TargetSubscriptions>();


			
			brokerTargetSubscriptions.Add(targetSubscriptions);
			targetSubscriptions.Add(broker, MessagePipe<T>.MessageType, MessagePipe<T>.Subscribe(broker, subscriber));
		}

		public void Publish<T>(T msg, IBroker broker) where T : struct, IMessage
		{
#if UNITY_EDITOR || DEBUG
			UnityEngine.Debug.Log($"#Events# {broker.GetType().FullName} raise event {MessagePipe<T>.MessageType.Name}");
#endif
			MessagePipe<T>.Publish(msg, broker);
		}
	}
}