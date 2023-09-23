using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
//OPTIMIZA MEMORIA

[CreateAssetMenu(fileName = "ActorStats",menuName = "Stats/WeaponStats",order = 0)]

public class WeaponStats : ScriptableObject
{
    //implemento y expongo
    //al no tener setter se mantiene seguridad
    [SerializeField] private WeaponStatValues _stats;
    
    //BULLETCOUNT NO SE AGREGA PORQUE COMO VA A VARIAR EL VALOR SE LO VA A CAMBIAR A TODAS LAS INSTANCIAS
    public int Damage => _stats.Damage;
    public int MagSize => _stats.MagSize;
    public string AttackTrigger => _stats.AttackTrigger;
}

[System.Serializable] 
public struct WeaponStatValues
{
    public string AttackTrigger;
    public int Damage;
    public int MagSize;
}
