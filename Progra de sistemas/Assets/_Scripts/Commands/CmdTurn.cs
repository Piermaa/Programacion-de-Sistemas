using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTurn : ICommand
{
    public bool CanUndo
    {
        get=>false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }

    //que se requiere para realizar?
    //propiedades
    
    private IMovable _movable;
    private float _direction;
    public CmdTurn(IMovable movable,float direction)
    {
        _movable = movable;
        _direction = direction;
    }

    public void Do()
    {
        _movable.Turn(_direction);
    }
    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}
