using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///   No se me ocurrio otra forma de comunicar los Animation events con los
/// scritps de sus parents.
///   Es necesario para que los enemigos se queden quietos al atacar y ataquen
/// en el momento correcto de la animacion
/// </summary>
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
