
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Aim : MonoBehaviour
{
    private const string Enemy="Enemy";
    private List<Actor> _targetsInRange=new();

    private void OnDisable()
    {
        _targetsInRange.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Enemy))
        {
            _targetsInRange.Add(other.GetComponent<Actor>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Enemy))
        {
            _targetsInRange.Remove(other.GetComponent<Actor>());
        }
    }
    

    public Actor GetClosestTarget()
    {
        var count = _targetsInRange.Count;
        if (count<0)
        {
            return null;
        }
        else
        {
            Actor nearestActor = null;
            float nearestDistance = float.MaxValue;
            
            for (int i = 0; i < count; i++)
            {
                float distance=Vector3.Distance(transform.position,_targetsInRange[i].transform.position);

                if (distance<nearestDistance && _targetsInRange[i]!=null)
                {
                    nearestActor = _targetsInRange[i];
                    nearestDistance = distance;
                }
            }
        
            return nearestActor;
        }


       
    }
    
    
    
}
