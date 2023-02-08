using PEPEngineers.PEPEvents.Implementation.Interfaces;

namespace PEPEngineers.PEPEvents.Implementation
{
	internal static class EventsManager
	{
		public static readonly IEventBus Instance = new CachedEventBus();
	}
}