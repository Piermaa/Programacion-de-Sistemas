using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTurn : ICommand
{
    #region Memento Properties 
    public bool CanUndo
    {
        get=>false;
        set => throw new System.NotImplementedException();
    }

    public float TimeToUndo { get; set; }
    #endregion
    
    //que se requiere para realizar?
    //propiedades
    
    private IMovable _movable;
    private float _direction;
    public CmdTurn(IMovable movable,float direction)
    {
        _movable = movable;
        _direction = direction;
    }
    
    #region ICommand Methods
    
    public void Do()
    {
        _movable.Turn(_direction);
    }
    public void Undo()
    {
        throw new System.NotImplementedException();
    }
    
    #endregion
    
}
