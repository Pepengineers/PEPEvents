using System;
using System.Collections.Generic;
using System.Linq;
using PEPEngineers.PEPEvents.Implementation.Interfaces;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Implementation
{
	internal sealed class TargetSubscriptions : ISubscriptions
	{
		private readonly Dictionary<IBroker, Dictionary<Type, IDisposable>> subscriptions = new();

		public TargetSubscriptions(ISubscriber subscriber)
		{
			Subscriber = subscriber;
		}

		public uint Count { get; private set; }

		public ISubscriber Subscriber { get; }
		public IEnumerable<IBroker> Brokers => subscriptions.Keys;
		public IEnumerable<Type> MessageTypes => subscriptions.Values.SelectMany(v => v.Keys);
		public IEnumerable<IDisposable> Subscriptions => subscriptions.Values.SelectMany(v => v.Values);

		public void AddIfNotExist(in IBroker broker,in Type type,in Func<IDisposable> unsubscribeFactory)
		{
			if (subscriptions.TryGetValue(broker, out var brokerSubs))
			{
				if (brokerSubs.ContainsKey(type)) 
					return;
			}
			else
			{
				brokerSubs = new Dictionary<Type, IDisposable>();
				subscriptions.Add(broker, brokerSubs);
			}

#if UNITY_EDITOR || DEBUG
			UnityEngine.Debug.Log(
				$"#Events# {Subscriber.GetType().Name} subscribe to {type.Name} in {broker.GetType().Name}");
#endif
			brokerSubs.Add(type, unsubscribeFactory());

			Count++;
		}

		public void Remove(in IBroker broker,in Type type)
		{
			if (Count <= 0) return;
			if (subscriptions.TryGetValue(broker, out var brokerSubscriptions))
			{
#if UNITY_EDITOR || DEBUG
				UnityEngine.Debug.Log(
					$"#Events# {Subscriber.GetType().Name} unsubscribe from {type.Name} in {broker.GetType().Name}");
#endif
				if (brokerSubscriptions.TryGetValue(type, out var targetSubscription))
				{
					targetSubscription.Dispose();
					Count--;
				}

				brokerSubscriptions.Remove(type);
			}
		}

		public void Remove(in IBroker broker)
		{
			if (Count <= 0) return;
			if (subscriptions.Remove(broker, out var brokerSubscriptions))
			{
				foreach (var brokerSubscription in brokerSubscriptions)
				{
#if UNITY_EDITOR || DEBUG
					UnityEngine.Debug.Log(
						$"#Events# {Subscriber.GetType().Name} unsubscribe from {brokerSubscription.Key.Name} in {broker.GetType().Name}");
#endif
					brokerSubscription.Value.Dispose();
					Count--;
				}

				brokerSubscriptions.Clear();
			}
		}

		public void RemoveAll()
		{
			if (Count <= 0) return;
			foreach (var targetSubscriptions in subscriptions)
			{
				foreach (var pair in targetSubscriptions.Value)
				{
#if UNITY_EDITOR || DEBUG
					UnityEngine.Debug.Log(
						$"#Events# {Subscriber.GetType().Name} unsubscribe from {pair.Key.Name} in {targetSubscriptions.Key.GetType().Name}");
#endif
					
					pair.Value.Dispose();
					Count--;
				}

				targetSubscriptions.Value.Clear();
			}

			subscriptions.Clear();
			Count = 0;
		}
	}
}