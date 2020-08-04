using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IGameEventListener
{
    void OnEventRaised();
}

public interface IGameEventListenerCurrencies : IGameEventListener
{
    void OnEventRaised(Currencies value);
}

public interface IGameEventListenerProduct : IGameEventListener
{
    void OnEventRaised(Product value);
}

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}