using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableProduct : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    GameEventEmitter selectedButtonEmitter;

    public void OnSelect(BaseEventData eventData)
    {
        selectedButtonEmitter.EmitEvent();
    }
}
