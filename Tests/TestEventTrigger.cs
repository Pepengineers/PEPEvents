using PEPEvents.Runtime;

namespace PEPEvents.Tests
{
	internal sealed class TestEventTrigger : GameEventTrigger<TestMessage>
	{
		public int Count;

		private void Awake()
		{
			onTriggered.AddListener(Call);
		}

		private void Call()
		{
			Count++;
		}
	}
}