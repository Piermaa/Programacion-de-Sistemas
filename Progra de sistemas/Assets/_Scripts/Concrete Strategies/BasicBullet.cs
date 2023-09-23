using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
 [RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BasicBullet : MonoBehaviour, IBullet, IProduct, IPooledObject
{
    [SerializeField] private BulletStats _stats;
    private float _currentLifeTime;
    
    #region IBullet Properties
    public int Damage => _stats.Damage;
    public float Speed => _stats.Speed;
    public float LifeTime =>_stats.LifeTime;
    public string HitteableTag => _stats.HitteableTag;
    #endregion

    public GameObject MyGameObject => this.gameObject;

    private Collider _collider;
    private Rigidbody _rigidbody;

    public string ObjectPoolerKey => PoolerKeys.BULLETS_KEY;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Actor>()?.TakeDamage(Damage);
        }
        gameObject.SetActive(false);
    }
    public IProduct Clone()
    {
        return ObjectPooler.Instance.SpawnFromPool(ObjectPoolerKey).GetComponent<IProduct>();
    }
    
    public void OnObjectSpawn()
    {
        _currentLifeTime = LifeTime;
    }

    public void SetStats(ScriptableObject stats)
    {
        _stats = stats as BulletStats;
    }
}
