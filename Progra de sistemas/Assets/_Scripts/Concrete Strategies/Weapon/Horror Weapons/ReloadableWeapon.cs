using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadableWeapon : Weapon
{
    #region Class Public Properties 

    public int BulletsInStock
    {
        set => bulletsInStock = value;
        get => bulletsInStock;
    }

    #endregion

    [SerializeField] private int bulletsInStock = 10;

   #region Weapon Overrided Methods
   
   public override void Attack()
   {
       if (remainingAttacks>0)
       {
           base.Attack();
       }
   }
   public override void Reload()
   {
       remainingAttacks += GetBulletsFromStock();
       UpdateUI();
   }

   public override void UpdateUI()
   {
       UIManager.Instance.WeaponsUI.UpdateBullets(AttackCount, bulletsInStock);
   }

   #endregion

   #region Class Methods

   private int GetBulletsFromStock()
   {
       var bulletsToAdd = MagSize - remainingAttacks;
       if (bulletsToAdd>bulletsInStock)
       {
           bulletsInStock = 0;
           return bulletsInStock;
       }
       else
       {
           bulletsInStock -= bulletsToAdd;
           return bulletsToAdd;
       }
   }

   #endregion
}
