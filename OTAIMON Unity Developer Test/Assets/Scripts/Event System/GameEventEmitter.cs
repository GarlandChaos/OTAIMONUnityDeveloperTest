using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventEmitter : MonoBehaviour
{
    public GameEvent Event;

    public void EmitEvent()
    {
        Event.Raise();
    }

    public void EmitEvent(Currencies value)
    {
        Event.Raise(value);
    }

    public void EmitEvent(Product value)
    {
        Event.Raise(value);
    }
}
