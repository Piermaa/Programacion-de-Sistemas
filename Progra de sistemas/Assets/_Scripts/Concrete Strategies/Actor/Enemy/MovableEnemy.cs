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
        //algo mal hice al importar todos los modelos 3d que si no hago esto se empiezan a desfazar del parent :c
        if (!IsDead)
        {
            _animator.gameObject.transform.localPosition = new Vector3(0, -1, 0);
        }
    }
}
