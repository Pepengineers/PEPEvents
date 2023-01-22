using PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEvents.Base
{
	public abstract class GameEventListener<TMessage, TEvent, TUnityAction> : GameEventSubscriber<TMessage, TEvent>
		where TMessage : struct, IMessage
		where TEvent : GameEvent<TMessage>
	{
		[SerializeField] private UnityEvent<TMessage> onGetMessage = new();

		public sealed override void OnNext(TMessage message)
		{
			onGetMessage?.Invoke(message);
		}
	}
}