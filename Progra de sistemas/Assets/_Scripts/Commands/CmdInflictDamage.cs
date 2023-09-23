using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdInflictDamage: ICommand
{
    public bool CanUndo
    {
        get => true;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }

    private Actor _target;
   private int _damage;
   private Transform _playerTransform;

   public CmdInflictDamage(Actor target, int damage, Transform playerTransform)
   {
       _target = target;
       _damage = damage;
       _playerTransform = playerTransform;
   }
    
   public void Do()
   {
         new CmdTakeDamage(_target,_damage).Do();
         //   target.TakeDamage(_stats.Damage);
         //TODO;
        /// Rotaba al pegarle al enemigo pero con el modelo 3D se rompe esto
        // var lookPos = _target.transform.position - _playerTransform.position;
        // lookPos.y = 0;
        // _playerTransform.rotation = Quaternion.LookRotation(lookPos);
   }

   public void Undo()
   {
       new CmdTakeDamage(_target,_damage).Undo();
   }
}
