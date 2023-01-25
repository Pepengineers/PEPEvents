using PEPEvents.Implementation.Interfaces;

namespace PEPEvents.Implementation
{
	internal static class EventsManager
	{
		public static readonly IEventBus Instance = new CachedEventBus();
	}
}