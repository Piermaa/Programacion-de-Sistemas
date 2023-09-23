using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int CurrentHealth { get; }
    int MaxHealth { get; }

    void TakeDamage(int damage);
    void Death();
    void Revive();
}