using PEPEngineers.PEPEvents.Runtime;

namespace PEPEngineers.PEPEvents.Tests
{
	internal sealed class TestEventSubscriber : GameEventSubscriber<TestMessage>
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