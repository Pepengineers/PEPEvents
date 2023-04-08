using PEPEngineers.PEPEvents.Runtime;

namespace PEPEngineers.PEPEvents.Tests
{
	internal sealed class TestEventTrigger : GameEventTrigger<TestMessage>
	{
		public int count;

		private void Awake()
		{
			Event.AddListener(Call);
		}

		private void Call()
		{
			count++;
		}
	}
}