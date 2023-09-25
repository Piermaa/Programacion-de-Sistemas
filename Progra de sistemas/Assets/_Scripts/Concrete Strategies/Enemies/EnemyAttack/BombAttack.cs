using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : EnemyAttack
{
    [SerializeField] private GameObject explosionEffect;
    public override void Attack(EnemyStats enemyStats, Transform attackOrigin)
    {
        if (!GetComponent<StaticEnemy>().IsDead) // porque como se llama al morir esto te podia pegar 2 veces, una por la muerte y otra porque el ataque llama la muerte
        {
            var actors = Physics.OverlapSphere(attackOrigin.position, enemyStats.AttackRange, enemyStats.WhatIsPlayer);

            foreach (Collider col in actors)
            {
                col.GetComponent<Actor>()?.TakeDamage(enemyStats.Damage);
            }

            Instantiate(explosionEffect, transform.position, transform.rotation); //todo pool de bombas
        
            GetComponent<IDamageable>().Death();
            gameObject.SetActive(false);
        }
    }
}
