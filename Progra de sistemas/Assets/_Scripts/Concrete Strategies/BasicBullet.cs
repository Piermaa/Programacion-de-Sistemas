using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
 [RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BasicBullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private LayerMask _hitteableLayers;
    [SerializeField] private IWeapon _owner;

    #region IBullet Properties
    public float Speed => _speed;
    public float LifeTime =>_lifeTime;
    public LayerMask HitteableLayers => _hitteableLayers;
    public string BulletType => throw new System.NotImplementedException();
    public IWeapon Owner => _owner;

    #endregion

    private Collider _collider;
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        
        Init();
    }

    private void Update()
    {
        Travel();

        _lifeTime -= Time.deltaTime;
        if (_lifeTime<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetOwner(IWeapon weapon) => _owner = weapon;
    public void Init()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    public void Travel()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
  
        /*
         un quilombo que metio el profe para hacer lo mismo, es un fix no se explico esto
         
        if(((1<<other.gameObject.layer)& _hitteableLayers)!=0)
            */
        if (_hitteableLayers==other.gameObject.layer)
        {
            print("a");
            other.GetComponent<Actor>()?.TakeDamage(_owner.Damage);
            //()?. es mas prolijo q trygetcomponent
        }
    }
}
