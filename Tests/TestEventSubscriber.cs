using PEPEngineers.PEPEvents.Runtime;

namespace PEPEngineers.PEPEvents.Tests
{
	internal sealed class TestEventSubscriber : UnityEventSubscriber<TestMessage>
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