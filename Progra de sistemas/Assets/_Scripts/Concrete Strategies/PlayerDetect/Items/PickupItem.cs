using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickupItem : OnPlayerTriggerEnter,IPooledObject
{
   #region IPooledObject Properties
   public string ObjectPoolerKey => _objectPoolerKey;
   private string _objectPoolerKey => "Item";
   #endregion

   #region Serializaed Variables

   [FormerlySerializedAs("period")] [SerializeField] float _period = 2f;
   [SerializeField] float _rotationSpeed = 2f;
   [SerializeField] private Vector3 _movementPosition;
   [SerializeField] [Range(0, 1)] private float _movementFactor;

   #endregion

   #region Class Properties

   protected Character _player;
   private Vector3 _startingPosition;

   #endregion

   #region Unity Callbacks

   void Start()
   {
      _startingPosition = transform.position;
   }

   void FixedUpdate()
   {
      //if (period == 0)
      //    return;

      if (_period <= Mathf.Epsilon)        //If period is less or equal to 0
         return;

      else
      {
         float cycles = Time.time / _period;  //Continually growing over time

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

   #endregion

   #region OnPlayerCharacterTriggerEnter Overrided Methods

   public override void OnPlayerCharacterTriggerEnter()
   {
      this.gameObject.SetActive(false);
   }

   #endregion

   #region IPooledObject Methods

   public void OnObjectSpawn()
   {
      _startingPosition = transform.position;
   }

   public void SetStats(ScriptableObject stats)
   {
      //todo en lugar de sacar de una pool random sacar siempre el mismo prefab y cambiar el sobject
   }

   #endregion
}
