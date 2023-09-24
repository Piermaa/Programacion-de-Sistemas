using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdEnemyAttack : ICommand
{
    #region Memento Properties

    public bool CanUndo {
        get
        {
            return false;
        }
        set
        {
            
        }
    }
    public float TimeToUndo { get; set; }

    #endregion

    #region Command Properties

    private IEnemyAttack _enemyAttack;
    private EnemyStats _stats;
    private Transform _attackOriginPosition;

    #endregion

    public CmdEnemyAttack(IEnemyAttack enemyAttack, EnemyStats stats, Transform attackOriginPosition)
    {
        _enemyAttack = enemyAttack;
        _stats = stats;
        _attackOriginPosition = attackOriginPosition;
    }

    #region ICommand Methods
    public void Do()
    {
        _enemyAttack.Attack(_stats,_attackOriginPosition);
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}