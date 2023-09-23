using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable
{
    //clase que implemente el como se lleva a cabo la estrategia
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject weaponsHolder;
    private Vector3 _meshLocalPos = new Vector3(0, -1, 0);
    private Quaternion _meshLocalRot=Quaternion.Euler(new Vector3(0, 0, 0));
    
    private void LateUpdate()
    {
        if (!_animator.GetBool("isWalking"))
        {
            _animator.transform.localPosition = _meshLocalPos;
            _animator.transform.localRotation = _meshLocalRot;
        }
    }

    public virtual void Move(float direction)
    {
        // if (weaponsHolder.activeInHierarchy)
        // {
        //     weaponsHolder.SetActive(false);
        // }

        _animator.SetBool("isWalking",true);
        transform.position += direction * Time.deltaTime * _movementSpeed* transform.forward;
    }

    public void StopMove()
    {
        _animator.SetBool("isWalking",false);
        weaponsHolder.SetActive(true);
    }

    public virtual void Turn(float direction)
    {
      transform.Rotate(direction*Time.deltaTime*_turnSpeed*Vector3.up);
    }

   
}
