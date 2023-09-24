using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdAttack : ICommand
{
    #region Memento Properties 


    public bool CanUndo
    {
        get => false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }

    #endregion
    
    private IWeapon _attackWeapon;
    public CmdAttack(IWeapon attackWeapon)
    {
        _attackWeapon = attackWeapon;
    }

    #region ICommand Methods

    public void Do()
    {
        _attackWeapon.Attack();
    }

    public void Undo()
    {
        //td
    }

    #endregion
  
}
