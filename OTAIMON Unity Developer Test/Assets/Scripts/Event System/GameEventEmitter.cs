using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventEmitter : MonoBehaviour
{
    public GameEvent Event;
    [HideInInspector]
    public string sceneToLoad;
    public bool thereIsASceneToLoad;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EmitEvent()
    {
        if (thereIsASceneToLoad)
        {
            Event.Raise(sceneToLoad);
        }
        else
        {
            Event.Raise();
        }
    }

    public void EmitEvent(float value)
    {
        Event.Raise(value);
    }

    public void EmitEvent(Currencies value)
    {
        Event.Raise(value);
    }
}
