using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventTrigger<TMessage> : MonoBehaviour where TMessage : struct, IMessage
	{
		[SerializeField] private GameEvent gameEvent;

		public void Raise(TMessage message)
		{
			gameEvent.Publish(message);
		}
	}
}