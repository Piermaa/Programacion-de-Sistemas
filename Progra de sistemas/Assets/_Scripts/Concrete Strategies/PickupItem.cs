using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickupItem : OnPlayerTriggerEnter
{
   protected Character _player;
   
   [SerializeField] float period = 2f;
   [SerializeField] float _rotationSpeed = 2f;
   [SerializeField] private Vector3 _movementPosition;
   [SerializeField] [Range(0, 1)] private float _movementFactor;
   private Vector3 _startingPosition;
   
   void Start()
   {
      _startingPosition = transform.position;
   }

   void FixedUpdate()
   {
      //if (period == 0)
      //    return;

      if (period <= Mathf.Epsilon)        //If period is less or equal to 0
         return;

      else
      {
         float cycles = Time.time / period;  //Continually growing over time

         const float tau = Mathf.PI * 2;     // constant value of 6.283 (2PI)

         float rawSinWave = Mathf.Sin(cycles * tau);     //going from -1 to 1

         _movementFactor = (rawSinWave + 1f) / 2f;        // recalculated to go from 0 to 1 so its cleaner

         Vector3 offset = _movementPosition * _movementFactor;
         transform.position = _startingPosition + offset;
      }

      transform.Rotate(0,_rotationSpeed*Time.deltaTime,0);
   }
   protected override void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag(PlayerTag))
      {
         _player = other.GetComponent<Character>();
         OnPlayerCharacterTriggerEnter();
      }
   }

   public override void OnPlayerCharacterTriggerEnter()
   {
      this.gameObject.SetActive(false);
   }
}
