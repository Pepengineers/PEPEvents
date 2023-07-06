using UnityEngine;
using UnityEngine.Events;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventSubscriber<TMessage> : EventSubscriber<TMessage>
	{
		[SerializeField] private UnityEvent<TMessage> onGetMessage = new();

		protected ref readonly UnityEvent<TMessage> Event => ref onGetMessage;

		public sealed override void OnNext(TMessage message)
		{
			onGetMessage?.Invoke(message);
		}
	}
}