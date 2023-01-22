using System;
using System.Collections.Generic;
using PEPEvents.Interface;

namespace PEPEvents.Implementation
{
	internal sealed class Subscription<T> : IDisposable where T : struct, IMessage
	{
		private readonly ICollection<Subscription<T>> pool;

		internal Subscription(ICollection<Subscription<T>> pool)
		{
			this.pool = pool;
		}

		public ICollection<ISubscriber<T>> Subscribers { get; internal set; }
		public ISubscriber<T> Subscriber { get; internal set; }

		public void Dispose()
		{
			if (Subscriber == null || Subscribers == null)
			{
				Free();
				return;
			}

			Subscribers.Remove(Subscriber);
			Free();
		}

		private void Free()
		{
			Subscriber = null;
			Subscribers = null;
			pool.Add(this);
		}
	}
}