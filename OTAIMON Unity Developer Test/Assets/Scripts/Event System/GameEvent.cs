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
            IGameEventListenerString listenerString = listeners[i] as IGameEventListenerString;
            if (listenerString != null)
            {
                listenerString.OnEventRaised((string)args[0]);
                continue;
            }
            IGameEventListenerFloat listenerFloat = listeners[i] as IGameEventListenerFloat;
            if (listenerFloat != null)
            {
                listenerFloat.OnEventRaised((float)args[0]);
                continue;
            }
            IGameEventListenerCurrencies listenerCurrencies = listeners[i] as IGameEventListenerCurrencies;
            if (listenerCurrencies != null)
            {
                listenerCurrencies.OnEventRaised((Currencies)args[0]);
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
