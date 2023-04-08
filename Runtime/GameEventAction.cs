using PEPEngineers.PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventAction<TMessage,TReturn> : GameEventSubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] protected UnityEvent<TReturn> onGetMessage = new();

		protected ref readonly UnityEvent<TReturn> Event => ref onGetMessage;
	}
}