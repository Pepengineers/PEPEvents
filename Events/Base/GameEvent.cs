using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events.Base
{
	public abstract class GameEvent : ScriptableObject, IBroker
	{
	}

	public abstract class GameEvent<T> : GameEvent, IBroker<T>
	{
		public virtual void Trigger(T message)
		{
			this.Publish(message);
		}
	}
}