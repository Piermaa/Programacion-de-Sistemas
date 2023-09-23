using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using UnityEngine;
//todo: static enemy y movable enemy
public class Enemy : Actor
{
    [SerializeField] private Transform attackOrigin;
    [SerializeField] protected Animator _animator;
    [SerializeField] private LayerMask whatIsPlayer;
   
    private EnemyStats _enemyStatsValues;
    private AgentController _agentController;

    private IEnemyAttack _enemyAttack;

    private float _attackTimer=0;
    private bool _playerInRange = false;
    
    protected override void Awake()
    {
        base.Awake();
        _enemyStatsValues = _stats as EnemyStats;
        _agentController = GetComponent<AgentController>();
        _enemyAttack = GetComponent<IEnemyAttack>();
    }
    
    private void FixedUpdate()
    {
        var coolDown = _enemyStatsValues.AttackCoolDown;
        _attackTimer = _attackTimer<coolDown? _attackTimer + Time.deltaTime : coolDown;
        
        if (_attackTimer >= coolDown && _playerInRange)
        {
            _animator.SetTrigger("Attack");
            _agentController.StopTime(1.5f);
            
            _enemyAttack.Attack(_enemyStatsValues,attackOrigin.position, whatIsPlayer);
            _attackTimer = 0;
        }
    }
    public void PlayerInRange(bool playerInRange)
    {
        _playerInRange = playerInRange;
    }
}
