using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnter : MonoBehaviour, IOnPlayerTriggerEnter
{
    #region IOnPlayerTriggerEnter Properties

    public string PlayerTag => _playerTag;
    [SerializeField] private string _playerTag = "Player";

    #endregion
  

    #region MonoBehaviour Callbacks

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            OnPlayerCharacterTriggerEnter();
        }
    }

    #endregion

    #region IOnPlayerTriggerEnter Methods

    public virtual void OnPlayerCharacterTriggerEnter()
    {
       
    }

    #endregion
}
