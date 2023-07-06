using PEPEngineers.PEPEvents.Runtime;

namespace PEPEngineers.PEPEvents.Tests
{
	internal sealed class TestEventSubscriber : TriggerSubscriber
	{
		public int count;

		private void Awake()
		{
			Delegate.AddListener(Call);
		}

		private void Call()
		{
			count++;
		}
	}
}