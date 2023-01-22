using PEPEvents.Extensions;
using PEPEvents.Implementation;
using PEPEvents.Interface;

namespace PEPEvents.Tests
{
	internal sealed class TestBroker : IBroker
	{
		public void Shutdown()
		{
			this.UnsubscribeAll();
		}
	}
}