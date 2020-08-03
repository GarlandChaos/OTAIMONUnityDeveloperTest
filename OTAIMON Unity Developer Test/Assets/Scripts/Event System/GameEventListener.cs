using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IGameEventListener
{
    void OnEventRaised();
}

public interface IGameEventListenerString : IGameEventListener
{
    void OnEventRaised(string element);
}

public interface IGameEventListenerFloat : IGameEventListener
{
    void OnEventRaised(float value);
}

public interface IGameEventListenerCurrencies : IGameEventListener
{
    void OnEventRaised(Currencies value);
}

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    public GameEvent Event;
    public UnityEvent Response;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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