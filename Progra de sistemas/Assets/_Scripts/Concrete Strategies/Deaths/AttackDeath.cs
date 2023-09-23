using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDeath : MonoBehaviour,IOnDeath
{
    public void Death()
    {
        GetComponent<MovableEnemy>().Attack();
        gameObject.SetActive(false);
    }
}
