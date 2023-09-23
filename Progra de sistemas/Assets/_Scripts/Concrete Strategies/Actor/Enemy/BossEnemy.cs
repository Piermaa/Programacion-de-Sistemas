using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BossPhase
{
    public string Tag;
    public EnemyAttack PhaseEnemyAttack;
    public Agent PhaseAgent;
    public GameObject Effects;
    public int HealthUmbral;
}

public class BossEnemy : MovableEnemy
{
    [SerializeField] private List<BossPhase> _bossPhases;
    private BossPhase _currentPhase=default;
    [SerializeField] private int _phase=0;
    protected override void Awake()
    {
        base.Awake();
        ChangePhase(_phase);
    }

    private bool CheckPhaseChange()
    {
        return CurrentHealth<_currentPhase.HealthUmbral;
    }

    private void ChangePhase(int index)
    {
        if (index>0)
        {
            _currentPhase.Effects.SetActive(false);
        }
        _animator.SetInteger("Phase",_phase);
        _currentPhase = _bossPhases[index];
        _currentPhase.Effects.SetActive(true);

        _enemyAttack = _currentPhase.PhaseEnemyAttack;
        _agentController.SetAgent(_currentPhase.PhaseAgent);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (CheckPhaseChange())
        {
            _phase++;
            ChangePhase(_phase);
        }
    }
}
