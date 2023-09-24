using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
 [RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BasicBullet : MonoBehaviour, IBullet, IProduct, IPooledObject
{
    #region Serialized Properties

    [SerializeField] private BulletStats _stats;

    #endregion

    #region Class Properties
    
    private float _currentLifeTime;
    private Collider _collider;
    private Rigidbody _rigidbody;

    #endregion
    
    #region IBullet Properties
    public int Damage => _stats.Damage;
    public float Speed => _stats.Speed;
    public float LifeTime =>_stats.LifeTime;
    public string HitteableTag => _stats.HitteableTag;
    #endregion

    #region IProduct Properties
    public GameObject MyGameObject => this.gameObject;
    #endregion

    #region IPooledObject Properties
    public string ObjectPoolerKey => PoolerKeys.BULLETS_KEY;
    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        
        Init();
    }

    private void Update()
    {
        Travel();

        _currentLifeTime -= Time.deltaTime;
        if (_currentLifeTime <=0)
        {
            gameObject.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Actor>()?.TakeDamage(Damage);
        }
        gameObject.SetActive(false);
    }


    #endregion
    
    #region IProduct Methods

    public IProduct Clone()
    {
        return ObjectPooler.Instance.SpawnFromPool(ObjectPoolerKey).GetComponent<IProduct>();
    }

    #endregion

    #region IPooledObject Methods

    public void OnObjectSpawn()
    {
        _currentLifeTime = LifeTime;
    }

    public void SetStats(ScriptableObject stats)
    {
        _stats = stats as BulletStats;
    }

    #endregion

    #region Class Methods
    public void Init()
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    public void Travel()
    {
        transform.position +=  Time.deltaTime * Speed * transform.forward;
    }

    #endregion
}
