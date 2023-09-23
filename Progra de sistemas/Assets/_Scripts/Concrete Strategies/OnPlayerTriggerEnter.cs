using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnter : MonoBehaviour, ICharacterDetection
{
    public string PlayerTag => _playerTag;
    [SerializeField] private string _playerTag = "Player";
    public virtual void OnPlayerCharacterTriggerEnter()
    {
       
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            OnPlayerCharacterTriggerEnter();
        }
    }
}
