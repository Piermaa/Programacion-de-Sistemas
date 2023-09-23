using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// no les voy a mentir esto lo saque de un video de brackeys el año pasaddo

public static class PoolerKeys
{
    public const string BULLETS_KEY = "Bullet";
}

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;  //crea un tipo de arreglo que requiere una llave (string) para acceder a cierto elemento (cola de gameobjects)

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); //anade al diccionario la cola de objetos

            for (int i=0; i<pool.size; i++)
            {
                //toask: La factory deberia llamar a pool o pool deberia llamar al factory? o da lo mismo
                GameObject obj = Instantiate(pool.prefab, transform);   //instancio objetos, los meto en la cola y los desactivo, desp los uso tpandolos y activandolos
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string key)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            Debug.LogWarning("Tag"+ key +"does not exists");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[key].Dequeue();
        //saca de la cola al objeto a despawnear

        objectToSpawn.SetActive(true);
        
        // IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();     //busca que haya una interface en el objeto a spawnear
        //
        // if (pooledObj != null)
        // {
        //     pooledObj.OnObjectSpawn(); // si tiene el tipo IPooledObject se llamara el metodo OnObjectSpawn() al spawnear el obj  //accede a la interfaz, busca la implementacion del metodo y lo executa
        // }
        poolDictionary[key].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
