using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CmdDie : ICommand
{
    public bool CanUndo
    {
        get => canUndo;
        set
        {
            canUndo = value;
        }
    }
    public float TimeToUndo 
    { 
        get=>_timeToUndo;
        set
        {
            _timeToUndo = value;
        }
    }

    private Collider _collider;
    private IDamageable _target;
    private Animator _animator;
    private bool canUndo = false;
    private float _timeToUndo=30;
    public CmdDie(IDamageable target, Animator animator, Collider collider)
    {
        _target = target;
        _animator = animator;
   
        _collider = collider;
    }
    
    public void Do()
    {
      _animator.SetTrigger("Death");
      _collider.enabled = false;
    }

    public void Undo()
    {
        _animator.ResetTrigger("Death"); //por si se le volvio a pegar al morir
        _animator.SetTrigger("Revive");
        _target.TakeDamage(-(int)(_target.MaxHealth*.3));
        _collider.enabled = true;
        ((StaticEnemy)_target).IsDead = false;
    }
}
