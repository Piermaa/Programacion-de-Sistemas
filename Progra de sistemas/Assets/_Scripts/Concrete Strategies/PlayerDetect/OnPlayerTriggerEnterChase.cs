using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnterChase : OnPlayerTriggerEnter
{
    [SerializeField] private AgentController _agentController;
    public override void OnPlayerCharacterTriggerEnter()
    {
        _agentController.SetAgent(1);//lo pone en chase
    }
}
