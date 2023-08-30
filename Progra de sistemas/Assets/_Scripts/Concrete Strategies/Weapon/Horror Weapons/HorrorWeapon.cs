using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hereda la estrategia!!!
public class HorrorWeapon : MonoBehaviour, IWeapon
{
    #region Public Properties
    #region IWeapon
    public WeaponStats Stats => _stats;

    public int Damage => _stats.Damage;

    public int MagSize => _stats.MagSize;
    public int BulletCount => _bulletCount;
    #endregion
    #endregion

    #region Private Properties

    [SerializeField] protected WeaponStats _stats;
    [SerializeField] protected Aim _aim;
    [SerializeField] protected int _bulletCount;
    [SerializeField] protected bool _isAiming;
    #endregion

    
    #region MONOBEHAVIOUR_CALLBACKS

    private void Awake()
    {
        StopAiming();
    }

    #endregion
    #region Methods
    public virtual void Attack()
    {
        Debug.Log("Shoot");
    }

    public void SpecialAttack()
    {
        Debug.Log("Shoot");
    }

    public void Aim()
    {
        _isAiming = true;
        _aim.gameObject.SetActive(true);
    }

    public void StopAiming()
    {
        _isAiming = false;
        _aim.gameObject.SetActive(false);
    }

    public void Reload() => _bulletCount = _stats.MagSize;

    public bool HasSpecialAttack()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
