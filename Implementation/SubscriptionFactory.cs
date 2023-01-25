using System;
using System.Collections.Generic;
using System.Linq;
using PEPEvents.Interface;

namespace PEPEvents.Implementation
{
	internal sealed class SubscriptionFactory<T> where T : struct, IMessage
	{
		private readonly List<Subscription<T>> freeSubscriptions = new();

		public IDisposable Create(ISubscriber<T> subscriber, ICollection<ISubscriber<T>> subscribers)
		{
			Subscription<T> subscription;
			if (freeSubscriptions.Any())
			{
				var lastIndex = freeSubscriptions.Count - 1;
				subscription = freeSubscriptions[lastIndex];
				freeSubscriptions.RemoveAt(lastIndex);
			}
			else
			{
				subscription = new Subscription<T>(freeSubscriptions);
			}

			subscription.Subscriber = subscriber;
			subscription.Subscribers = subscribers;
			return subscription;
		}
	}
}