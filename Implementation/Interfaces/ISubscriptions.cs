using System;
using System.Collections.Generic;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Implementation.Interfaces
{
	internal interface ISubscriptions
	{
		public ISubscriber Subscriber { get; }

		public IEnumerable<IBroker> Brokers { get; }

		public IEnumerable<Type> MessageTypes { get; }

		public IEnumerable<IDisposable> Subscriptions { get; }
	}
}