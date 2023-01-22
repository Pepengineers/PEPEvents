using PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEvents.Base
{
	public abstract class GameEventTrigger<TMessage, TEvent> : GameEventSubscriber<TMessage, TEvent>
		where TMessage : struct, IMessage
		where TEvent : GameEvent
	{
		[SerializeField] protected UnityEvent onTriggered = new();

		public sealed override void OnNext(TMessage message)
		{
			onTriggered?.Invoke();
		}
	}
}