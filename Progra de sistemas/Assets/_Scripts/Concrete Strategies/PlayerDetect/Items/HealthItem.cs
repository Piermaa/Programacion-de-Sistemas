using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : PickupItem
{
    [SerializeField] private int maxHeal = 10;

    public override void OnPlayerCharacterTriggerEnter()
    {
        _player.Heal(Random.Range(1,maxHeal));
        base.OnPlayerCharacterTriggerEnter();
    }
}
