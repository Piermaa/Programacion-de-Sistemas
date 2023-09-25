using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class WinGameManager : MonoBehaviour, IListener
{
    
    #region Ilistener Properties
    public string EventID => _eventID;
    #endregion
    
    [SerializeField] private string _eventID;
    
    #region IListener Methods

    public void OnEventDispatch()
    {
        StartCoroutine(WaitToWin());
    }

    //el jefe cuando ataca explota en la ultima fase, si explota no llega a matar al player sin esta corrutina 
    private IEnumerator WaitToWin()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Win");
    }

    #endregion
   
}