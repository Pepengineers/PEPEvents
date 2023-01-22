using System;
using System.Collections.Generic;
using System.Linq;
using PEPEvents.Interface;

namespace PEPEvents.Implementation
{
	internal sealed class TargetSubscriptions : ISubscriptions
	{
		private readonly Dictionary<IBroker, Dictionary<Type, IDisposable>> subscriptions = new();

		public TargetSubscriptions(ISubscriber subscriber)
		{
			Subscriber = subscriber;
		}
		
		public ISubscriber Subscriber { get; }
		public IEnumerable<IBroker> Brokers => subscriptions.Keys;
		public IEnumerable<Type> MessageTypes => subscriptions.Values.SelectMany(v => v.Keys);
		public IEnumerable<IDisposable> Subscriptions => subscriptions.Values.SelectMany(v => v.Values);

		public uint Count { get; private set; } = 0;

		public void Add(IBroker broker, Type type, IDisposable unsubscribe)
		{
#if UNITY_EDITOR || DEBUG
			UnityEngine.Debug.Log(
				$"#Events# {Subscriber.GetType().Name} subscribe to {type.Name} in {broker.GetType().FullName}");
#endif
			if (subscriptions.TryGetValue(broker, out var brokerSubs))
			{
				brokerSubs.Add(type, unsubscribe);
			}
			else
			{
				brokerSubs = new Dictionary<Type, IDisposable> { { type, unsubscribe } };
				subscriptions.Add(broker, brokerSubs);
			}

			Count++;
		}

		public void Remove(IBroker broker, Type type)
		{
			if (Count <= 0) return;
			if (subscriptions.TryGetValue(broker, out var brokerSubscriptions))
			{
#if UNITY_EDITOR || DEBUG
				UnityEngine.Debug.Log($"#Events# {Subscriber.GetType().Name} unsubscribe from {broker.GetType().FullName}");
#endif
				if (brokerSubscriptions.TryGetValue(type, out var targetSubscriptions))
				{
					targetSubscriptions.Dispose();
					Count--;
				}
				brokerSubscriptions.Remove(type);
			}
		}

		public void Remove(IBroker broker)
		{
			if (Count <= 0) return;
			if (subscriptions.Remove(broker, out var brokerSubscriptions))
			{
				foreach (var brokerSubscription in brokerSubscriptions)
				{
#if UNITY_EDITOR || DEBUG
					UnityEngine.Debug.Log($"#Events# {Subscriber.GetType().Name} unsubscribe from {broker.GetType().FullName}");
#endif
					brokerSubscription.Value.Dispose();
					Count--;
				}
				brokerSubscriptions.Clear();
			}
		}

		public void RemoveAll()
		{
			foreach (var targetSubscriptions in subscriptions)
			{
#if UNITY_EDITOR || DEBUG
				UnityEngine.Debug.Log($"#Events# {Subscriber.GetType().Name} unsubscribe from {targetSubscriptions.Key.GetType().FullName}");
#endif
				foreach (var subscription in targetSubscriptions.Value.Values)
				{
					subscription.Dispose();
					Count--;
				}
				targetSubscriptions.Value.Clear();
			}

			subscriptions.Clear();
			Count = 0;
		}
	}
}