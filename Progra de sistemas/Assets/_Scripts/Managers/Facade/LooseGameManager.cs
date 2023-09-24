using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LooseGameManager : IListener
{
    #region Ilistener Properties
    public string EventID => _eventID;
    #endregion
    [SerializeField] private string _eventID;

    #region IListener Methods
    public void OnEventDispatch()
    {
        SceneManager.LoadScene("GameOver");
    }
    #endregion
}
