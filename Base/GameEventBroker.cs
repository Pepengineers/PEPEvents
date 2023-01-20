using PEPEvents.Implementation;
using PEPEvents.Interface;
using UnityEngine;

namespace PEPEvents.Base
{
	public abstract class GameEventBroker : MonoBehaviour, IBroker
	{
	}

	public abstract class GameEventBroker<T> : GameEventBroker where T : struct, IMessage
	{
		protected virtual void OnDestroy()
		{
			EventHub.Instance.Remove<T>(this);
		}
	}

	public abstract class GameEventBroker<T, T1> : GameEventBroker
		where T : struct, IMessage
		where T1 : struct, IMessage
	{
		protected virtual void OnDestroy()
		{
			EventHub.Instance.Remove<T>(this);
			EventHub.Instance.Remove<T1>(this);
		}
	}

	public abstract class GameEventBroker<T, T1, T2> : GameEventBroker
		where T : struct, IMessage
		where T1 : struct, IMessage
		where T2 : struct, IMessage
	{
		protected virtual void OnDestroy()
		{
			EventHub.Instance.Remove<T>(this);
			EventHub.Instance.Remove<T1>(this);
			EventHub.Instance.Remove<T2>(this);
		}
	}
}