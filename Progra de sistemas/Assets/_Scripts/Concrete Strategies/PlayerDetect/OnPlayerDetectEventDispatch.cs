using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDetectEventDispatch : OnPlayerTriggerEnter
{
    [SerializeField] private string _eventID;
    private void Awake()
    {
        EventsManager.Instance.RegisterEvent(_eventID);
    }

    public override void OnPlayerCharacterTriggerEnter()
    {
        EventsManager.Instance.DispatchSimpleEvent(_eventID);
    }
}
