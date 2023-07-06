using PEPEngineers.PEPEvents.Events.Base;
using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class EventSubscriber<TMessage> : MonoBehaviour, ISubscriber<TMessage>
	{
		[SerializeField] private GameEvent gameEvent;
		public IBroker GameEvent => gameEvent;

		protected virtual void OnEnable()
		{
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