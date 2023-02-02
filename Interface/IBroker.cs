namespace PEPEvents.Interface
{
	public interface IBroker
	{
	}

	public interface IBroker<T> : IBroker where T : struct, IMessage
	{
	}
}