using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnterAttack : OnPlayerTriggerEnter
{
    [SerializeField] private StaticEnemy _enemy;
    public override void OnPlayerCharacterTriggerEnter()
    {
       _enemy.PlayerInRange(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemy.PlayerInRange(false);
        }
    }
}
