using PEPEvents.Base;

namespace PEPEvents.Tests
{
	internal sealed class TestEventTrigger : GameEventTrigger<TestMessage,TestGameEvent>
	{
		public int Count = 0;
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