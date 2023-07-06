using PEPEngineers.PEPEvents.Events.Base;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(Float4GameEvent), fileName = nameof(Float4GameEvent), order = 0)]
	internal sealed class FloatGameEvent : GameEvent<float>
	{
		
	}
}