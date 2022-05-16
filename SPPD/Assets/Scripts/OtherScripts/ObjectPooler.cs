using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooler : MonoBehaviour
{
    #region Custom Class
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #endregion

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region Public Fields
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab,transform.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    #endregion

    #region Public Methods
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation,bool target,Vector3 targetDirection)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }



        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.GetComponent<Bullet>().SetTargetDirection(targetDirection, target);
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

   
    #endregion
}
