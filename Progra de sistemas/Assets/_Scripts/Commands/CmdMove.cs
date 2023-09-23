using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMove : ICommand
{
    
    public bool CanUndo
    {
        get => false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }
    //EL COMANDO DEBE SER LO MAS EXCLUSIVO PRIVADA POSIBLE, UNA VEZ SE CIERRA EL COMANDO
    //NO DEBE SER MODIFICADO
    //SE DEBE SER FIEL A LOS DATOS LLAMADOS
    //SI NO LOS PODEMOS SETEAR, COMO LOS PODEMOS SETEAR?
    //con constructor

    private float _direction;
    private IMovable _movable;
    public CmdMove(IMovable movable, float direction)
    {
        _direction = direction;
        _movable = movable;
    }

    public void Do()
    {
        _movable.Move(_direction);
    }

    public void Undo()
    {
        //td
    }
    //elimina move
}