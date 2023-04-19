using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class EventTrigger<TMessage> : MonoBehaviour where TMessage : struct, IMessage
	{
		[SerializeField] private GameEvent gameEvent;
		public ref readonly GameEvent GameEvent => ref gameEvent;

		public void Raise(TMessage message)
		{
			gameEvent.Publish(message);
		}
	}
}