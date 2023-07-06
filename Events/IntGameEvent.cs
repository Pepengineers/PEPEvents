using PEPEngineers.PEPEvents.Events.Base;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(IntGameEvent), fileName = nameof(IntGameEvent), order = 0)]
	internal sealed class IntGameEvent : GameEvent<int>
	{
		
	}
}