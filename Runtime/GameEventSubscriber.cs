using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventSubscriber<TMessage, TEvent> : MonoBehaviour, ISubscriber<TMessage>
		where TMessage : struct, IMessage
		where TEvent : GameEvent
	{
		[SerializeField] private TEvent gameEvent;
		public ref readonly TEvent GameEvent => ref gameEvent;

		protected virtual void OnEnable()
		{
			if (gameEvent == null)
				return;

			gameEvent.Subscribe(this);
		}

		protected virtual void OnDisable()
		{
			this.UnsubscribeAll();
		}

		protected virtual void OnDestroy()
		{
			this.UnsubscribeAll();
		}


		public abstract void OnNext(TMessage message);
	}
}