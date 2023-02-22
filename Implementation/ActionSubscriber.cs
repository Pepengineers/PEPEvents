using System;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Implementation
{
	internal sealed class ActionSubscriber<TMessage> : ISubscriber<TMessage> where TMessage : struct, IMessage
	{
		private readonly Action<TMessage> action;

		public ActionSubscriber(Action<TMessage> userAction)
		{
			action = userAction;
		}

		public void OnNext(TMessage message)
		{
			action(message);
		}
	}
}