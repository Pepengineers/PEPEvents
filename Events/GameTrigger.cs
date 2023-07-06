using PEPEngineers.PEPEvents.Data;
using PEPEngineers.PEPEvents.Events.Base;
using PEPEngineers.PEPEvents.Extensions;
using UnityEngine;

namespace PEPEngineers.PEPEvents.Events
{
	[CreateAssetMenu(menuName = "Events/" + nameof(GameTrigger), fileName = nameof(GameTrigger), order = 0)]
	internal sealed class GameTrigger : GameEvent
	{
		public void Trigger()
		{
			this.Publish(new Void());
		}
	}
}