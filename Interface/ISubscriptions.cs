using System;
using System.Collections.Generic;

namespace PEPEvents.Interface
{
	public interface ISubscriptions
	{
		public ISubscriber Subscriber { get; }
		
		public IEnumerable<IBroker> Brokers { get; }
		
		public IEnumerable<Type> MessageTypes { get; }
		
		public IEnumerable<IDisposable> Subscriptions { get; }
	}
}