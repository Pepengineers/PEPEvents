using PEPEngineers.PEPEvents.Events.Base;
using Unity.Mathematics;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(Float4GameEvent), fileName = nameof(Float4GameEvent), order = 0)]
	internal sealed class Float4GameEvent : GameEvent<float4>
	{
		
	}
}