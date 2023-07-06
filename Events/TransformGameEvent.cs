using PEPEngineers.PEPEvents.Events.Base;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(TransformGameEvent), fileName = nameof(TransformGameEvent), order = 0)]
	internal sealed class TransformGameEvent : GameEvent<Transform>
	{
		
	}
}