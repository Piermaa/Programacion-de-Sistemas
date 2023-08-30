using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorPistol : HorrorWeapon
{
   public override void Attack()
   {
      if (_isAiming)
      {
         _aim.GetClosestTarget()?.TakeDamage(_stats.Damage);
      }
   }
}
