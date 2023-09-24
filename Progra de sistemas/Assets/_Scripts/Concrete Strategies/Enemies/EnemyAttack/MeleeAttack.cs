using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : EnemyAttack
{
    public override void Attack(EnemyStats enemyStats, Transform attackOrigin)
    {
        var playerCollider= Physics.OverlapSphere(attackOrigin.position, enemyStats.AttackRange,enemyStats.WhatIsPlayer);
        if (playerCollider.Length > 0)
        {
            playerCollider[0].GetComponent<Character>().TakeDamage(enemyStats.Damage);
        }
    }
}
