using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable
{
    //clase que implemente el como se lleva a cabo la estrategia
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _movementSpeed;
    public virtual void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * _movementSpeed;
    }
    
    public virtual void Turn(float direction)
    {
      transform.Rotate(Vector3.up*direction*Time.deltaTime*_turnSpeed);
    }
}
