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
			var subscription = freeSubscriptions.Any() 
				? freeSubscriptions.First() : new Subscription<T>(freeSubscriptions);
			
			subscription.Subscriber = subscriber;
			subscription.Subscribers = subscribers;
			return subscription;
		}
	}
}