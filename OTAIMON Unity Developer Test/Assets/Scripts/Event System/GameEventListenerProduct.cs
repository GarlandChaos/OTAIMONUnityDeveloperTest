using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameEventProduct : UnityEvent<Product> { }

public class GameEventListenerProduct : MonoBehaviour, IGameEventListenerProduct
{
    public GameEvent Event;
    public GameEventProduct Response;

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

    public void OnEventRaised(Product value)
    {
        Response.Invoke(value);
    }
}
