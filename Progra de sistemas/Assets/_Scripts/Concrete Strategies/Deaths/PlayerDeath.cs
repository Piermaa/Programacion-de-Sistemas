using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath
    : MonoBehaviour, IOnDeath
{
    public void Death()
    {
        EventsManager.Instance.DispatchSimpleEvent(GameManager.instance.LooseManager.EventID);    
    }
}

