using PEPEngineers.PEPEvents.Events.Base;
using Unity.Mathematics;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(Float3GameEvent), fileName = nameof(Float3GameEvent), order = 0)]
	internal sealed class Float3GameEvent : GameEvent<float3>
	{
		
	}
}