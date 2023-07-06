using PEPEngineers.PEPEvents.Data;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEngineers.PEPEvents.Runtime
{
	public class TriggerSubscriber : EventSubscriber<Void>
	{
		[SerializeField] private UnityEvent onTriggered = new();

		public ref readonly UnityEvent Delegate => ref onTriggered;

		public override void OnNext(Void message)
		{
			Delegate?.Invoke();
		}
	}
}