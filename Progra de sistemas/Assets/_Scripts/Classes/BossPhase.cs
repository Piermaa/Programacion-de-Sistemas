using System;
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