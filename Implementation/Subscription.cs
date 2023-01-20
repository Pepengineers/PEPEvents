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

			if (Subscribers.Remove(Subscriber))
			{
#if UNITY_EDITOR || DEBUG
				UnityEngine.Debug.Log($"#Events# {Subscriber.GetType().Name} unsubscribe from {typeof(T).Name}");
#endif
			}
#if UNITY_EDITOR || DEBUG
			else
			{
				UnityEngine.Debug.LogWarning("You tried delete noe exist subscriber from broker subscribers list");
			}
#endif
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