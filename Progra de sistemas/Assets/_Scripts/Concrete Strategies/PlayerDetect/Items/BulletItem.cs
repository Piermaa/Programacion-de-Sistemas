using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : PickupItem
{
    [SerializeField] private int maxBulletsToAdd = 10;
    [SerializeField] private int minBulletsToAdd = 1;
    [SerializeField] [Tooltip("1 Pistol, 2 Shotgun")] [Range(1,2)]private int weaponIndex;
    public override void OnPlayerCharacterTriggerEnter()
    {
        _player.PickUpBullets(weaponIndex,Random.Range(minBulletsToAdd, maxBulletsToAdd));
        base.OnPlayerCharacterTriggerEnter();
    }
}
