using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReload : ICommand
{
   public bool CanUndo
   {
      get => false;
      set => throw new System.NotImplementedException();
   }

   public float TimeToUndo { get; set; }
   private IWeapon _weaponToReload;

   public CmdReload(IWeapon weaponToReload)
   {
      _weaponToReload = weaponToReload;
   }

   public void Do()
   {
      _weaponToReload.Reload();
   }

   public void Undo()
   {
      throw new System.NotImplementedException();
   }
}
