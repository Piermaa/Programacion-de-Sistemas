using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCharacterDetector : OnPlayerTriggerEnter
{
    [SerializeField] private StaticEnemy _enemy;
    public override void OnPlayerCharacterTriggerEnter()
    {
       _enemy.PlayerInRange(true);
    }
}
