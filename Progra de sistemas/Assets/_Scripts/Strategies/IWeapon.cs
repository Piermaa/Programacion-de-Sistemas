using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    WeaponStats Stats { get; }
    int Damage { get; }
    int BulletCount { get; }
    int MagSize { get; }

    void Aim();
    void StopAiming();
    void Attack();
    void SpecialAttack();
    bool HasSpecialAttack();
    void Reload();
}


public interface IBullet
{
    float Speed { get; }
    float LifeTime { get; }
    LayerMask HitteableLayers { get; }
    string BulletType { get; }
    IWeapon Owner { get; }

    void SetOwner(IWeapon weapon);
    void Init();
    void Travel();
}
