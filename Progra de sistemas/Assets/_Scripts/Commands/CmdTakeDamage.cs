using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTakeDamage : ICommand
{
    #region Memento Properties

    public bool CanUndo
    {
        get=>false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }

    #endregion
    
    private IDamageable _victim; //acceso a takedamage
    private int _damage;

    public CmdTakeDamage(IDamageable victim, int damage)
    {
        _victim = victim;
        _damage = damage;
    }

    #region ICommand Methods

    public void Do()
    {
        _victim.TakeDamage(_damage);
    }

    public void Undo()
    {
        _victim.TakeDamage(-_damage);
    }

    #endregion

    
}
