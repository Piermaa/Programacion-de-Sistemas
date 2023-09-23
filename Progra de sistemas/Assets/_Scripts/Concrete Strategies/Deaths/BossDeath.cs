using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour, IOnDeath
{
    public void Death()
    {
        EventsManager.Instance.DispatchSimpleEvent(GameManager.instance.WinManager.EventID);    
    }
}
