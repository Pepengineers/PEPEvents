using PEPEvents.Extensions;
using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Base
{
	public abstract class TargetGameEventListener<TMessage> : MonoBehaviour, ISubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] private TargetGameEventBroker target;

		protected virtual void OnEnable()
		{
			if(target == null)
				return;
			target.Subscribe(this);
		}

		protected virtual void OnDisable()
		{
			this.UnsubscribeAll();
		}

		public abstract void OnNext(TMessage message);
	}
}