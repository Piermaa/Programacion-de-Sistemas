using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour,IWeapon
{
    [SerializeField] private float _bulletPerShell=10;
    
    #region Public Properties
    #region IWeapon
    public GameObject Bullet => _bullet;
    public WeaponStats Stats { get; }
    public int Damage => _damage;

    public int MagSize => _magSize;
    public void Aim()
    {
        throw new System.NotImplementedException();
    }

    public void StopAiming()
    {
        throw new System.NotImplementedException();
    }

    public int BulletCount => _bulletCount;
    #endregion
    #endregion

    #region Private Properties
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected int _damage;
    [SerializeField] protected int _magSize;
    [SerializeField] protected int _bulletCount;
    #endregion

    #region Methods
    public void Attack()
    {
        if (_bulletCount > 0)
        {
            for (int i = 0; i < _bulletPerShell; i++)
            {//EN LUGAR DE PONER UNA POS FIJA PONE UNA POSICION RANDOM EN UNA ESFERA DE 1 DE RADIO
                Instantiate(_bullet, transform.position + Random.insideUnitSphere * 1, Quaternion.identity)
                    .GetComponent<BasicBullet>().SetOwner(this);
            }
            _bulletCount--;
        }
    }
    public void SpecialAttack()
    {
        Debug.Log("Shoot");
    }

    public void Reload() => _bulletCount = _magSize;

    public bool HasSpecialAttack()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
