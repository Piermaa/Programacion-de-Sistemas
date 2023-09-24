using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  #region Facade

  public WinGameManager WinManager => _winGameManager;
  public LooseGameManager LooseManager => _looseGameManager;
    
  [SerializeField] private WinGameManager _winGameManager;
  [SerializeField] private LooseGameManager _looseGameManager;
  #endregion
    
  #region Singleton

  public static GameManager instance;

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy(this);
    }
    
    EventsManager.Instance.RegisterEvent(_winGameManager.EventID);
    EventsManager.Instance.AddListener(_winGameManager.EventID, _winGameManager);
    
    EventsManager.Instance.RegisterEvent(_looseGameManager.EventID);
    EventsManager.Instance.AddListener(_looseGameManager.EventID, _looseGameManager);
  }

  #endregion

  #region EventQueue

  private Queue<ICommand> _events = new();
  private List<ICommand> _doneEvents = new();
  private bool isCharacterFrozen;
  public void AddEvents(ICommand cmd) => _events.Enqueue(cmd);

  private void Update()
  {
    while (_events.Count > 0)
    {
      var cmd = _events.Dequeue();

      //guardo
      if (cmd.CanUndo)
      {
        _doneEvents.Add(cmd);
      }

      cmd.Do();
    }

    for (int i = _doneEvents.Count - 1; i >= 0; i--)
    {
      _doneEvents[i].TimeToUndo -= Time.deltaTime;
      
      if (_doneEvents[i].TimeToUndo <= 0)
      {
        _doneEvents[i].Undo();
        _doneEvents.Remove(_doneEvents[i]);
      }
    }
  }

  #endregion
}





