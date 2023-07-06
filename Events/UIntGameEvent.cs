using PEPEngineers.PEPEvents.Events.Base;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(UIntGameEvent), fileName = nameof(UIntGameEvent), order = 0)]
	internal sealed class UIntGameEvent : GameEvent<uint>
	{
	}
}