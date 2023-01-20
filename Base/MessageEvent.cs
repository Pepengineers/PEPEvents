using PEPEvents.Extensions;
using PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEvents.Base
{
	public abstract class MessageEvent<TMessage> : MonoBehaviour, ISubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] private UnityEvent<TMessage> onTriggered = new();

		protected virtual void OnEnable()
		{
			Subscribe();
		}

		protected virtual void OnDisable()
		{
			this.UnsubscribeAll();
		}

		protected virtual void OnDestroy()
		{
			this.UnsubscribeAll();
		}

		void ISubscriber<TMessage>.OnNext(TMessage message)
		{
			onTriggered?.Invoke(message);
		}

		protected abstract void Subscribe();
	}
}