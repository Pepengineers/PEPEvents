using System;
using PEPEngineers.PEPEvents.Interface;

namespace PEPEngineers.PEPEvents.Implementation
{
	internal sealed class ActionSubscriber<TMessage> : ISubscriber<TMessage> 
	{
		private readonly Action<TMessage> action;
		private readonly ISubscriber user;

		public ActionSubscriber(ISubscriber user, Action<TMessage> userAction)
		{
			this.user = user;
			action = userAction;
		}

		public void OnNext(TMessage message)
		{
			action(message);
		}

		public override int GetHashCode()
		{
			return user.GetHashCode();
		}
	}
}