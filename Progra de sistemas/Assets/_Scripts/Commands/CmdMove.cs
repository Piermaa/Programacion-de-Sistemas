using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMove : ICommand
{
    #region Memento Properties

    public bool CanUndo
    {
        get => false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }

    #endregion
    
    //EL COMANDO DEBE SER LO MAS EXCLUSIVO PRIVADA POSIBLE, UNA VEZ SE CIERRA EL COMANDO
    //NO DEBE SER MODIFICADO
    //SE DEBE SER FIEL A LOS DATOS LLAMADOS
    //SI NO LOS PODEMOS SETEAR, COMO LOS PODEMOS SETEAR?
    //con constructor

    #region Command Properties

    private float _direction;
    private IMovable _movable;

    #endregion

    public CmdMove(IMovable movable, float direction)
    {
        _direction = direction;
        _movable = movable;
    }

    #region ICommand Methods

    public void Do()
    {
        _movable.Move(_direction);
    }

    public void Undo()
    {
        //td
    }

    #endregion
  
}