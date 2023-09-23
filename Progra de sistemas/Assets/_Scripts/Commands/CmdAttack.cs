using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdAttack : ICommand
{

    public bool CanUndo
    {
        get => false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }
    private IWeapon _attackWeapon;

    public CmdAttack(IWeapon attackWeapon)
    {
        _attackWeapon = attackWeapon;
    }


    public void Do()
    {
        _attackWeapon.Attack();
    }

    public void Undo()
    {
        //td
    }
}
