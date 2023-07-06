using PEPEngineers.PEPEvents.Events.Base;
using Unity.Mathematics;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(Float2GameEvent), fileName = nameof(Float2GameEvent), order = 0)]
	internal sealed class Float2GameEvent : GameEvent<float2>
	{
		
	}
}