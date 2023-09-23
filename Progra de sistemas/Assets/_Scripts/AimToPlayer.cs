using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToPlayer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void FixedUpdate()
    {
        var lookPos = _playerTransform.position - transform.position; 
        lookPos.y = 0;
        if (lookPos!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookPos);
        }
    }
}
