using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IWeapon
{
    WeaponStats Stats { get; }
    int Damage { get; }
    int AttackCount { get; }
    int MagSize { get; }

    void Aim();
    void StopAiming();
    void Attack();
    void Reload();
    void UpdateUI();
}


public interface IBullet
{
    int Damage { get; }
    float Speed { get; }
    float LifeTime { get; }
    string HitteableTag { get; }
    void Init();
    void Travel();
}
