using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemDeath : MonoBehaviour, IOnDeath
{
    [SerializeField] private string itemsTag="Item";
    public void Death()
    {
       var item= ObjectPooler.Instance.SpawnFromPool(itemsTag + Random.Range(1, 4));
       item.transform.position = transform.position;
    }
}
