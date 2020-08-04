using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void Raise(params object[] args)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            IGameEventListenerCurrencies listenerCurrencies = listeners[i] as IGameEventListenerCurrencies;
            if (listenerCurrencies != null)
            {
                listenerCurrencies.OnEventRaised((Currencies)args[0]);
                continue;
            }
            IGameEventListenerProduct listenerProduct = listeners[i] as IGameEventListenerProduct;
            if (listenerProduct != null)
            {
                listenerProduct.OnEventRaised((Product)args[0]);
                continue;
            }
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(IGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
