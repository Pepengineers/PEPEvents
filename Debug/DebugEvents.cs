using System.Linq;
using System.Text;
using PEPEvents.Implementation;
using UnityEditor;

namespace PEPEvents.Debug
{
	public static class DebugEvents
	{
		private static readonly StringBuilder Builder = new();

		[MenuItem("Debug/Tools/Event Hub Dump")]
		public static void PrintDump()
		{
			Builder.Clear();
			Builder.AppendLine("EventHub DUMP");
			var subscriptions = EventsManager.Instance.Subscriptions;
			Builder.AppendLine($"Alive subscriptions {subscriptions.Count}");
			foreach (var subscription in subscriptions)
				Builder.AppendLine($"\t {subscription.Subscriber.GetType().FullName}");

			Builder.AppendLine($"Alive brokers: {subscriptions.SelectMany(s => s.Brokers).Count()}");
			foreach (var subscription in subscriptions)
				for (var i = 0; i < subscription.Brokers.Count(); i++)
				{
					var broker = subscription.Brokers.ElementAt(i);
					var messageType = subscription.MessageTypes.ElementAt(i);
					Builder.AppendLine($"\t {broker.GetType().FullName} -> {messageType.FullName}");
				}

			UnityEngine.Debug.Log(Builder.ToString());
		}
	}
}