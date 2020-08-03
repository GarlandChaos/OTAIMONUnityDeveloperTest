using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameEventCurrencies : UnityEvent<Currencies> { }

public class GameEventListenerCurrencies : MonoBehaviour, IGameEventListenerCurrencies
{
    public GameEvent Event;
    public GameEventCurrencies Response;

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
        Debug.Log("Cannot use this version");
    }

    public void OnEventRaised(Currencies value)
    {
        Response.Invoke(value);
    }
}
