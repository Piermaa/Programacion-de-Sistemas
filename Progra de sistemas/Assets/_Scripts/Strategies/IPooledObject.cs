using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    string ObjectPoolerKey { get; }
    void OnObjectSpawn();
    void SetStats(ScriptableObject stats);
}
