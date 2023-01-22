using System;
using PEPEvents.Extensions;
using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Base
{
	public abstract class TargetGameEventBroker : MonoBehaviour, IBroker
	{
		protected virtual void OnDestroy()
		{
			this.UnsubscribeAll();
		}
	}
}