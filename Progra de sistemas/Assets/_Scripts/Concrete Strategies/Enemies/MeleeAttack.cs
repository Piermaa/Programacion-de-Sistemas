using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : EnemyAttack
{
    public override void Attack(EnemyStats enemyStats, Vector3 attackOriginPosition, LayerMask whatIsPlayer)
    {
        var playerCollider= Physics.OverlapSphere(attackOriginPosition, enemyStats.AttackRange,whatIsPlayer);
        if (playerCollider.Length > 0)
        {
            playerCollider[0].GetComponent<Character>().TakeDamage(enemyStats.Damage);
        }
    }
}
