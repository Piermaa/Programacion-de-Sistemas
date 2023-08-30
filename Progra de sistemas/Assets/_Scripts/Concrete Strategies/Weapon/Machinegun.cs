using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Machinegun : MonoBehaviour, IWeapon
{
    #region SERIALIZED_VARIABLES

    [SerializeField] private float _bulletPerShot=5;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected int _damage=7;
    [SerializeField] protected int _magSize = 30;
    [SerializeField] protected int _bulletCount;

    #endregion

    #region IWeapon Properties
    
    public GameObject Bullet => _bullet;
    public int Damage => _damage;
    public int BulletCount => _bulletCount;
    public int MagSize => _magSize;
    public void Aim()
    {
        throw new NotImplementedException();
    }

    public void StopAiming()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region MONOBEHAVIOUR_CALLBACKS

    private void Start()
    {
      Reload();
    }

    #endregion
    
    
    #region IWEAPON_ACTIONS

    public void Attack()
    {
        if (_bulletCount > 0)
        {
            for (int i = 0; i < _bulletPerShot; i++)
            {//EN LUGAR DE PONER UNA POS FIJA PONE UNA POSICION RANDOM EN UNA ESFERA DE 1 DE RADIO
              Instantiate(_bullet, transform.position -Vector3.forward*i/10, Quaternion.identity)
                  .GetComponent<BasicBullet>().SetOwner(this);
              
              
            }
            _bulletCount--;
        }
    }

    public void SpecialAttack() => Debug.Log("Spec ac");
 
    public bool HasSpecialAttack() => false;
    
    public void Reload() => _bulletCount = _magSize;

    #endregion


}
