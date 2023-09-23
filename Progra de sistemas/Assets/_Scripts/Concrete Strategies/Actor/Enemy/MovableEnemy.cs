using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : StaticEnemy
{
    protected AgentController _agentController;

    protected override void Awake()
    {
        base.Awake();
        _agentController = GetComponent<AgentController>();
    }
}
