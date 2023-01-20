using PEPEvents.Interface;

namespace GameAssets.Code.Events.Tests
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