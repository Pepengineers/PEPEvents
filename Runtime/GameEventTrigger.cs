﻿using PEPEngineers.PEPEvents.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace PEPEngineers.PEPEvents.Runtime
{
	public abstract class GameEventTrigger<TMessage> : GameEventSubscriber<TMessage>
		where TMessage : struct, IMessage
	{
		[SerializeField] private UnityEvent onTriggered = new();

		protected ref readonly UnityEvent Event => ref onTriggered;

		public sealed override void OnNext(TMessage message)
		{
			Event?.Invoke();
		}
	}
}