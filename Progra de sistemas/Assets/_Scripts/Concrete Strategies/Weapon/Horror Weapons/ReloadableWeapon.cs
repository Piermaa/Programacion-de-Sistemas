using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadableWeapon : Weapon
{
    public int BulletsInStock
    {
        set => bulletsInStock = value;
        get => bulletsInStock;
    }

    [SerializeField] private int bulletsInStock = 10;
   public override void Attack()
   {
       if (remainingAttacks>0)
       {
           base.Attack();
       }
   }

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

   public override void Reload()
   {
       remainingAttacks += GetBulletsFromStock();
       UpdateUI();
   }

   public override void UpdateUI()
   {
       UIManager.Instance.WeaponsUI.UpdateBullets(AttackCount, bulletsInStock);
   }
}
