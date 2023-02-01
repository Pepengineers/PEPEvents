using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Runtime
{
	public abstract class GameEvent : ScriptableObject, IBroker
	{
	}

	public abstract class GameEvent<TMessage> : GameEvent, IBroker<TMessage>
		where TMessage : struct, IMessage
	{
	}
}