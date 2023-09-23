using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalDeath : MonoBehaviour, IOnDeath
{
    public void Death()
    {
        var die = new CmdDie(GetComponent<IDamageable>(), GetComponentInChildren<Animator>(), GetComponent<Collider>());

        die.CanUndo = Random.Range(0, 10) > 7;
        GameManager.instance.AddEvents(die);
    }
}