using NUnit.Framework;
using PEPEvents.Extensions;
using PEPEvents.Implementation;
using UnityEngine.TestTools;

namespace GameAssets.Code.Events.Tests
{
	[RequiresPlayMode(false)]
	public class EventTests
	{
		private readonly TestMessage message = new();
		private TestBroker broker;
		private TestSubscriber subscriber;

		[SetUp]
		public void SetUp()
		{
			subscriber = new TestSubscriber();
			broker = new TestBroker();
		}

		[TearDown]
		public void Teardown()
		{
			subscriber.UnsubscribeAll();
		}

		[Test]
		public void GlobalSubscription()
		{
			EventHub.Instance.Subscribe(broker, subscriber);
			broker.RaiseMessage(message);
			Assert.AreEqual(subscriber.OnNextValue, 1);
		}

		[Test]
		public void TargetSubscription()
		{
			EventHub.Instance.Subscribe(broker, subscriber);
			broker.RaiseMessage(message);
			Assert.AreEqual(subscriber.OnNextValue, 1);
		}

		[Test]
		public void TargetEventCount()
		{
			EventHub.Instance.Subscribe(broker, subscriber);
			for (var i = 0; i < 10; i++) broker.RaiseMessage(message);

			broker.Shutdown();

			Assert.AreEqual(subscriber.OnNextValue, 10);
		}
	}
}