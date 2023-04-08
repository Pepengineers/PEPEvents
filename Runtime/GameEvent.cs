using PEPEngineers.PEPEvents.Extensions;
using PEPEngineers.PEPEvents.Interface;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Runtime
{
	[CreateAssetMenu(menuName = "Events/" + nameof(GameEvent), fileName = nameof(GameEvent), order = 0)]
	public class GameEvent : ScriptableObject, IBroker
	{
		
	}

	public abstract class GameEvent<TMessage> : GameEvent, IBroker<TMessage>
		where TMessage : struct, IMessage
	{
	}
}