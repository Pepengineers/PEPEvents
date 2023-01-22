using PEPEvents.Interface;

namespace PEPEvents.Tests
{
	internal sealed class TestSubscriber : ISubscriber<TestMessage>
	{
		public int OnNextValue;

		public void OnNext(TestMessage message)
		{
			OnNextValue++;
		}
	}
}