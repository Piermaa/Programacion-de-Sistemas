using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttack
{
    void Attack(EnemyStats enemyStatistics, Transform attackOrigin);
}

/// <summary>
/// Necesitaba esta clase para poder arrastrar los enemy attacks en el inspector del jefe :P
/// </summary>
public class EnemyAttack : MonoBehaviour, IEnemyAttack
{
    public virtual void Attack(EnemyStats enemyStats, Transform attackOriginPosition)
    {
        
    }
}
