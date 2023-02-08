using System.Collections.Generic;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Implementation.Interfaces
{
	internal interface IEventBus
	{
		IReadOnlyCollection<ISubscriptions> Subscriptions { get; }
		void Subscribe<T>(IBroker broker, ISubscriber<T> subscriber) where T : struct, IMessage;
		void Unsubscribe<T>(IBroker broker, ISubscriber<T> subscriber) where T : struct, IMessage;
		void Publish<T>(T msg, IBroker broker) where T : struct, IMessage;
		void UnsubscribeAll(ISubscriber subscriber);
		void UnsubscribeAll(IBroker subscriber);
	}
}