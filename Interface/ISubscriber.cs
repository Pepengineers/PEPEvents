using System;

namespace PEPEngineers.PEPEvents.Interface
{
	public interface ISubscriber<in TMessage> : ISubscriber
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