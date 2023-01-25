# PEPEvents
Fast Event system for Unity with IDisposables and without unnecessary allocations

## System Requirements
Unity **2019.4** or later versions. Don't forget to include the PEPools namespace and add assemly defenition reference. 

## Installation
You can also install via git url by adding this entry in your **manifest.json**
```
"com.pepervice": "https://github.com/Pepengineers/PEPEvents",
```
## Overview

# IMessage

The IMessage interface is needed to bind your game data to be publish to the subscriber.
To pass the data you want to all subscribers of the object you need to inherit this data from the IMessage interface

```csharp

public enum KeyStatus : sbyte
{
  Pressed,
  Unpressed
}

public readonly struct KeyChangeStatus : IMessage
{
  public readonly string Name;
  public readonly KeyStatus Status;
  public KeyChangeStatus(string name, KeyStatus status)
  {
    Name = name;
    Status = status;
  }
}

```

Implemented extension method in PEPEvents.Extensions namespace for userfrendly work with messages

```csharp

public static void Publish<T>(this IBroker broker, T message);

```

# IBroker and ISubscriber<TMessage>

To create your own data providers and subscribers you need IBroker and ISubscriber<T> interfaces respectively

```csharp

public readonly struct TestMessage : IMessage
{
}

internal sealed class TestSubscriber : ISubscriber<TestMessage>
{
  public int OnNextValue;
  public void OnNext(TestMessage message)
  {
    OnNextValue++;
  }
}

internal sealed class TestBroker : IBroker
{
  public void Shutdown()
  {
    this.UnsubscribeAll();
  }
}


var subscriber = new TestSubscriber();
var broker = new TestBroker();
broker.Subscribe(subscriber);
broker.Publish(new TestMessage());

```
Extension methods have been added to make it easier to subscribe and unsubscribe from brokers/subscribers

```csharp

public static void Subscribe<TMessage>(this ISubscriber<TMessage> subscriber, IBroker broker);
public static void Subscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber);
public static void Unsubscribe<TMessage>(this ISubscriber<TMessage> subscriber, IBroker broker);
public static void Unsubscribe<TMessage>(this IBroker broker, ISubscriber<TMessage> subscriber);
public static void UnsubscribeAll(this ISubscriber subscriber);
public static void UnsubscribeAll(this IBroker broker);

```

# GameEvent

ScriptableObject class for the game event.
To create a custom event, you need to inherit it and specify the `CreateAssetMenu` attribute

```csharp

[CreateAssetMenu(menuName = "Create Event/Input/PressAnyKeyEvent", fileName = "PressAnyKeyEvent", order = 0)]
internal sealed class PressAnyKeyEvent : GameEvent {}

```
There is also a Generic version of this class which will be associated with IMessage data

```csharp

[CreateAssetMenu(menuName = "Create Event/Input/PressAnyKeyEvent", fileName = "PressAnyKeyEvent", order = 0)]
internal sealed class PressAnyKeyEvent : GameEvent<KeyChangeStatus> {}

```

# GameEventSubscriber

MonoBehaviour encapsulating GameEvent subscription mechanism 
Needed if you want to implement `OnNext(TMessage message)` from the code

```csharp

internal sealed class TestUnitySubscriber : GameEventSubscriber<TestMessage, TestGameEvent>
{
  public override void OnNext(TestMessage message)
  {
  }
}

```
# GameEventTrigger

Сontains a built-in UnityEvent for subscribing other components to events

```csharp

internal sealed class TestUnityTrigger : GameEventTrigger<TestMessage, TestGameEvent>
{
}

```
![изображение](https://user-images.githubusercontent.com/17476222/214702379-a0eac14c-9f15-4509-ae30-1fcb49278e7f.png)

You can also specify the second type is not Generic GameEvent in order to be able to subscribe to any events


```csharp

internal sealed class TestUnityTrigger : GameEventTrigger<TestMessage, GameEvent>
{
}

```

# GameEventListener

The same as GameEventTrigger but if your game component also gets data from the message.

Contains UnityEvent<TMessage>


```csharp

internal sealed class TestUnityListener : GameEventListener<TestMessage, TestGameEvent>
{
}

```
![изображение](https://user-images.githubusercontent.com/17476222/214702774-ceddc599-a929-407b-aa7e-c3f4f7d0aa90.png)

