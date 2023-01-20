using PEPEvents.Extensions;
using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Base
{
	public abstract class GlobalMessageEvent<T> : MessageEvent<T> where T : struct, IMessage
	{
		[SerializeField] private GlobalEventBroker target;

		protected override void Subscribe()
		{
			this.Subscribe(target);
		}
	}
}