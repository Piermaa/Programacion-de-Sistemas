using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//hereda la estrategia!!!
//todo: separar balas y recarga de iweapon, armas a melee no se recargan
public class Weapon : MonoBehaviour, IWeapon
{
    #region Public Properties
    #region IWeapon
    public WeaponStats Stats => _stats;

    public int Damage => _stats.Damage;

    public int MagSize => _stats.MagSize;
    public int AttackCount => remainingAttacks;
    #endregion
    #endregion

    #region Private Properties

    [SerializeField] protected WeaponStats _stats;
    [SerializeField] protected Aim _aim;
    [SerializeField] protected int remainingAttacks;
    [SerializeField] protected bool _isAiming;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Animator playerAnimator;
    #endregion
    
    #region MONOBEHAVIOUR_CALLBACKS

    protected void Awake()
    {
        StopAiming();
        remainingAttacks = _stats.MagSize;
    }

    #endregion
    #region Methods
    public virtual void Attack()
    {
        if (_isAiming)
        {
            //ataca y consume balas
            remainingAttacks--;
            playerAnimator.SetTrigger(_stats.AttackTrigger);
            UpdateUI();
            // si encuentra a alguien le hace daño
            var target = _aim.GetClosestTarget();

            if (target!=default)
            {
                new CmdInflictDamage(target, _stats.Damage, playerTransform).Do();
            }
            //todo: mover esto a character de alguna forma
        }
    }

    public virtual void UpdateUI()
    {
        UIManager.Instance.WeaponsUI.UpdateBullets(remainingAttacks,MagSize);
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

    public virtual void Reload()
    {
        print("cannotReload");
    }

    #endregion
}
