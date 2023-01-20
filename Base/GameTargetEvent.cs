using PEPEvents.Extensions;
using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Base
{
	public abstract class GameTargetEvent<TMessage> : MessageEvent<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] private GameEventBroker target;

		protected override void Subscribe()
		{
			this.Subscribe(target);
		}
	}
}