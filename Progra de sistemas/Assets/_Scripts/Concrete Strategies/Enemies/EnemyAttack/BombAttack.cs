using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : EnemyAttack
{
    [SerializeField] private GameObject explosionEffect;
    public override void Attack(EnemyStats enemyStats, Vector3 attackOriginPosition, LayerMask whatIsPlayer)
    {
        var actors = Physics.OverlapSphere(attackOriginPosition, enemyStats.AttackRange, whatIsPlayer);

        foreach (Collider col in actors)
        {
            col.GetComponent<Actor>()?.TakeDamage(enemyStats.Damage);
        }

        Instantiate(explosionEffect, transform.position, transform.rotation); //todo pool de bombas
        GetComponent<IDamageable>().Death();
        gameObject.SetActive(false);
    }
}
