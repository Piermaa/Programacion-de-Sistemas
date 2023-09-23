using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//por ahi podria llamarse base enemy porque el detector dice q static enemy haga algo pero el detector del movable le estaria diciendo al movible que es estatico y haga algo
public class StaticEnemy : Actor
{
    public bool IsDead
    {
        set => _isDead = value;
        get => _isDead;
    }

    [SerializeField] protected Transform attackOrigin;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected LayerMask whatIsPlayer;
 
    protected EnemyStats _enemyStatsValues;
    protected IEnemyAttack _enemyAttack;

    private float _attackTimer=0;
    private bool _playerInRange = false;
    private bool _isDead=false;   
    protected override void Awake()
    {
        base.Awake();
        _enemyStatsValues = _stats as EnemyStats;
        _enemyAttack = GetComponent<IEnemyAttack>();
    }
    
    private void FixedUpdate()
    {
        var coolDown = _enemyStatsValues.AttackCoolDown;
        _attackTimer = _attackTimer<coolDown? _attackTimer + Time.deltaTime : coolDown;
        
        if (_attackTimer >= coolDown && _playerInRange)
        {
            BeginAttack();   
        }
    }

    protected void BeginAttack()
    {
        _animator.SetTrigger("Attack");
        _attackTimer = 0;
    }

    public void Attack()
    {
        _enemyAttack.Attack(_enemyStatsValues,attackOrigin.position, whatIsPlayer); //todo: cmd
    }

    public void PlayerInRange(bool playerInRange)
    {
        _playerInRange = playerInRange;
    }

    public override void Death()
    {
        if (!_isDead)
        {
            _isDead = true;
            var deaths = GetComponents<IOnDeath>();
            if(deaths.Length>0)
            {
                foreach (var death in deaths)
                {
                    death.Death();
                }
            }
        }
    }
}
