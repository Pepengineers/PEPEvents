using PEPEvents.Extensions;
using PEPEvents.Implementation;
using PEPEvents.Interface;

namespace GameAssets.Code.Events.Tests
{
	internal sealed class TestBroker : IBroker
	{
		public void RaiseMessage(TestMessage message)
		{
			this.Publish(message);
		}

		public void Shutdown()
		{
			EventHub.Instance.Remove<TestMessage>(this);
		}
	}
}