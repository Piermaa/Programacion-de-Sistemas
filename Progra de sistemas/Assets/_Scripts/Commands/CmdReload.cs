using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReload : ICommand
{
   #region Memento Properties

   public bool CanUndo
   {
      get => false;
      set => throw new System.NotImplementedException();
   }

   public float TimeToUndo { get; set; }

   #endregion
   
   private IWeapon _weaponToReload;

   public CmdReload(IWeapon weaponToReload)
   {
      _weaponToReload = weaponToReload;
   }

   #region ICommand Methods

   public void Do()
   {
      _weaponToReload.Reload();
   }

   public void Undo()
   {
      throw new System.NotImplementedException();
   }

   #endregion
  
}
