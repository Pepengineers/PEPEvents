using PEPEngineers.PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventSubscriber<TMessage> : EventSubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] private UnityEvent onTriggered = new();

		protected ref readonly UnityEvent Delegate => ref onTriggered;

		public sealed override void OnNext(TMessage message)
		{
			Delegate?.Invoke();
		}
	}
	
	
	public abstract class GameEventSubscriber<TMessage, TUnityEventType> : EventSubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] protected UnityEvent<TUnityEventType> onGetMessage = new();

		protected ref readonly UnityEvent<TUnityEventType> Event => ref onGetMessage;
	}
}