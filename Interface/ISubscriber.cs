using System;

namespace PEPEvents.Interface
{
	public interface ISubscriber<in TMessage> : ISubscriber where TMessage : struct, IMessage
	{
		void OnNext(TMessage message);
	}

	public interface ISubscriber
	{
		public void OnError(Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}
}