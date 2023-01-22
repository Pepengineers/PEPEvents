using System.Collections;
using NUnit.Framework;
using PEPEvents.Extensions;
using PEPEvents.Implementation;
using UnityEngine;
using UnityEngine.TestTools;

namespace PEPEvents.Tests
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
		public void TargetSubscription()
		{
			EventHub.Instance.Subscribe(broker, subscriber);
			broker.Publish(message);
			Assert.AreEqual(subscriber.OnNextValue, 1);
		}

		[Test]
		public void TargetEventCount()
		{
			EventHub.Instance.Subscribe(broker, subscriber);
			for (var i = 0; i < 10; i++) broker.Publish(message);

			broker.Shutdown();

			Assert.AreEqual(subscriber.OnNextValue, 10);
		}


		[UnityTest]
		[RequiresPlayMode(true)]
		public IEnumerator TargetGameEventSubscription()
		{
			var trigger = new GameObject("TestTrigger").AddComponent<TestEventTrigger>();
			trigger.Subscribe(broker);
			yield return null;

			broker.Publish(message);
			
			Assert.AreEqual(trigger.Count, 1);
		}
	}
}