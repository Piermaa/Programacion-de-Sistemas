using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ActorStats",menuName = "Stats/EnemyStats",order = 0)]

public class EnemyStats : ActorStats
{
    [SerializeField] private EnemyStatsValues _enemyStatsValues;
    public int Damage => _enemyStatsValues.Damage;
    public float AttackRange => _enemyStatsValues.AttackRange;
    public float AttackCoolDown => _enemyStatsValues.AttackCoolDown;
}
[System.Serializable]
public struct EnemyStatsValues
{
    public int Damage;
    public float AttackRange;
    public float AttackCoolDown;
}