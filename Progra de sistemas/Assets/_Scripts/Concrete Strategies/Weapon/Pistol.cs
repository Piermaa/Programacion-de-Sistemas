using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour,IWeapon
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
    public WeaponStats Stats { get; }
    public int Damage => _damage;
    public int BulletCount => _bulletCount;
    public int MagSize => _magSize;
    public void Aim()
    {
        throw new System.NotImplementedException();
    }

    public void StopAiming()
    {
        throw new System.NotImplementedException();
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
           Instantiate(_bullet, transform.position, Quaternion.identity)
               .GetComponent<BasicBullet>().SetOwner(this);
            
            _bulletCount--;
        }
    }
    
    public void SpecialAttack() => Debug.Log("Spec ac");
 
    public bool HasSpecialAttack() => false;
    
    public void Reload() => _bulletCount = _magSize;

    #endregion
}

