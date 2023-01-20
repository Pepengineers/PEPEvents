using PEPEvents.Interface;

namespace PEPEvents.Implementation
{
	public static class EventHub
	{
		public static readonly IEventBus Instance = new CachedEventBus();
	}
}