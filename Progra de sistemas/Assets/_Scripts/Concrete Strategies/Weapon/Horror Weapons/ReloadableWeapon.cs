using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ReloadableWeapon : Weapon
{
    #region Class Public Properties 

    public int BulletsInStock
    {
        set => _bulletsInStock = value;
        get => _bulletsInStock;
    }

    #endregion

    #region Serialized Variables

    [FormerlySerializedAs("bulletsInStock")] [SerializeField] private int _bulletsInStock = 10;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private ParticleSystem _muzzleShotParticles;
    [SerializeField] private AudioSource _reloadSound;

    #endregion
   
   #region Weapon Overrided Methods
   
   public override void Attack()
   {
       if (remainingAttacks>0)
       {
           base.Attack();
           
           if (_isAiming)
           {
               _shootSound.PlayOneShot(_shootSound.clip);
               _muzzleShotParticles.Play();
           }
       }
   }
   public override void Reload()
   {
       if (_bulletsInStock>0)
       {
           remainingAttacks += GetBulletsFromStock();
           UpdateUI();
           _reloadSound.Play();
       }
   }

   public override void UpdateUI()
   {
       UIManager.Instance.WeaponsUI.UpdateBullets(AttackCount, _bulletsInStock);
   }

   #endregion

   #region Class Methods

   private int GetBulletsFromStock()
   {
       var bulletsToAdd = MagSize - remainingAttacks;
       
       if (bulletsToAdd>_bulletsInStock) //si me faltan mas balas que las que tengo
       {
           //agrego todas y pongo en 0
           var temp = _bulletsInStock; 
           _bulletsInStock = 0;
           return temp;
       }
       else
       {
           _bulletsInStock -= bulletsToAdd;
           return bulletsToAdd;
       }
   }

   #endregion
}
