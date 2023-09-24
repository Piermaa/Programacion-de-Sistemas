using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class WinGameManager : IListener
{
    
    #region Ilistener Properties
    public string EventID => _eventID;
    #endregion
    
    [SerializeField] private string _eventID;
    
    #region IListener Methods

    public void OnEventDispatch()
    {
        SceneManager.LoadScene("Win");
    }

    #endregion
   
}