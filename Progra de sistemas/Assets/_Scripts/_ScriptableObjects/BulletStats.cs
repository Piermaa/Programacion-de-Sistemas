using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
//OPTIMIZA MEMORIA

[CreateAssetMenu(fileName = "ActorStats",menuName = "Stats/BulletStats",order = 0)]

public class BulletStats : ScriptableObject
{
    //implemento y expongo
    //al no tener setter se mantiene seguridad
    [SerializeField] private BulletStatValues _stats;
    
    //BULLETCOUNT NO SE AGREGA PORQUE COMO VA A VARIAR EL VALOR SE LO VA A CAMBIAR A TODAS LAS INSTANCIAS
    public int Damage => _stats.Damage;
    public float Speed => _stats.Speed;
    public float LifeTime => _stats.LifeTime;
    public string HitteableTag => _stats.HitteableTag;
}

[System.Serializable] 
public struct BulletStatValues
{
    public float LifeTime;
    public int Speed;
    public int Damage;
    public string HitteableTag;
}
