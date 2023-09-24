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

    private void LateUpdate()
    {
        _animator.gameObject.transform.localPosition = new Vector3(0, -1, 0);
    }
}
