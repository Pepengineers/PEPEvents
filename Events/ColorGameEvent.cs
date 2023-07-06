using PEPEngineers.PEPEvents.Events.Base;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(ColorGameEvent), fileName = nameof(ColorGameEvent), order = 0)]
	internal sealed class ColorGameEvent : GameEvent<Color>
	{
		
	}
}