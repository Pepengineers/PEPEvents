using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEvent : ScriptableObject, IBroker
	{
	}

	public abstract class GameEvent<TMessage> : GameEvent, IBroker<TMessage>
		where TMessage : struct, IMessage
	{
	}
}