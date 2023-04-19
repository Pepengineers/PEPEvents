using System.Collections;
using NUnit.Framework;
using PEPEngineers.PEPEvents.Extensions;
using UnityEngine;
using UnityEngine.TestTools;

namespace PEPEngineers.PEPEvents.Tests
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
			broker.Subscribe(subscriber);
			broker.Publish(message);
			Assert.AreEqual(subscriber.OnNextValue, 1);
		}

		[Test]
		public void TargetEventCount()
		{
			broker.Subscribe(subscriber);
			for (var i = 0; i < 10; i++) broker.Publish(message);

			broker.Shutdown();

			Assert.AreEqual(subscriber.OnNextValue, 10);
		}


		[UnityTest]
		[RequiresPlayMode]
		public IEnumerator TargetGameEventSubscription()
		{
			var trigger = new GameObject("TestTrigger").AddComponent<TestEventSubscriber>();
			broker.Subscribe(trigger);
			yield return null;

			broker.Publish(message);

			Assert.AreEqual(trigger.count, 1);
		}
	}
}