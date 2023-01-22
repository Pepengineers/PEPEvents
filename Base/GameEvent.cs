using System;
using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Base
{
	public abstract class GameEvent : ScriptableObject, IBroker
	{
		
	}

	public abstract class GameEvent<TMessage> : GameEvent 
		where TMessage : struct, IMessage
	{
		
	}
}