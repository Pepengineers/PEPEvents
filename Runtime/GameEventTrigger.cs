using PEPEngineers.PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventTrigger<TMessage> : GameEventSubscriber<TMessage, GameEvent>
		where TMessage : struct, IMessage
	{
		[SerializeField] protected UnityEvent onTriggered = new();

		public sealed override void OnNext(TMessage message)
		{
			onTriggered?.Invoke();
		}
	}

	public abstract class GameEventTrigger<TMessage, TEvent> : GameEventSubscriber<TMessage, TEvent>
		where TMessage : struct, IMessage
		where TEvent : GameEvent
	{
		[SerializeField] protected UnityEvent<TMessage> onGetMessage = new();

		public sealed override void OnNext(TMessage message)
		{
			onGetMessage?.Invoke(message);
		}
	}
}