using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class EventSubscriber<TMessage> : MonoBehaviour, ISubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] private GameEvent gameEvent;
		public IBroker GameEvent => gameEvent;

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