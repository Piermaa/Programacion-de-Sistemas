using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyAttack
{
    #region Serialized Variables

    [SerializeField] private BulletStats _bulletStats;
    [SerializeField] private GameObject _bullet;

    #endregion
    
    private BulletFactory _bulletFactory;
    private void Awake()
    {
        _bulletFactory = new BulletFactory(_bullet.GetComponent<BasicBullet>());
    }

    public override void Attack(EnemyStats enemyStatistics, Transform attackOrigin)
    {
        
        //SE OBTIENE UNA BULLET DE LA FACTORY
        //las bullet de por si ya estan guardades en una pool
        IProduct bullet = _bulletFactory.CreateProduct();
        BasicBullet bulletAsBullet=bullet as BasicBullet;
        bulletAsBullet.transform.SetPositionAndRotation(attackOrigin.position,attackOrigin.rotation);
        bulletAsBullet.SetStats(_bulletStats); //seteo estadisticas porque las bullet del jefe y el enemigo son distintas
        
        bulletAsBullet.GetComponent<IPooledObject>().OnObjectSpawn(); //reseteo lifetime //Todo: que la bala se achique con el tiempo, tmb resetear escala
    }
}

