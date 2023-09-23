using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimationEvent : MonoBehaviour
{
    private StaticEnemy _enemy;
    private AgentController _agentController;
    private void Awake()
    {
        _enemy = GetComponentInParent<StaticEnemy>();
        _agentController = GetComponentInParent<AgentController>();
    }

    public void Enemy_Attack()
    {
        _enemy.Attack();
    }

    public void Agent_Stop()
    {
        _agentController.CantMove();
    }

    public void Agent_Resume()
    {
        _agentController.CanMove();
    }
}
