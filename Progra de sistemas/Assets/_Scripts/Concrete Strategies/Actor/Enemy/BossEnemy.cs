using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MovableEnemy
{
    #region Serialized Variables

    [SerializeField] private List<BossPhase> _bossPhases;
    [SerializeField] private int _phase=0;

    #endregion
    
    private BossPhase _currentPhase=default;

    #region Unity Callbacks

    private void Start()
    {
        ChangePhase(_phase);
    }

    #endregion

    #region Class Methods

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

    #endregion
    
    #region Actor Overrided Methods

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (CheckPhaseChange())
        {
            _phase++;
            ChangePhase(_phase);
        }
    }

    #endregion

  
}
