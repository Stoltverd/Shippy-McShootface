using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    //Make this a singleton
    public static Pooler Instance;
    private void Awake()
    {
        Instance = this;
    }


    //Pool class
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField]
    private GameObject spawnParent;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            //Instantiate objects in pool
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);

                obj.transform.SetParent(spawnParent.transform);
            }
            // Add pool to dictionary
            poolDict.Add(pool.tag, objPool);
        }
    }

    //This function activates objects
    public GameObject SpawnFromPool (string tag, Vector3 location, Quaternion rotation)
    {
        GameObject spawnableObject = poolDict[tag].Dequeue();

        spawnableObject.SetActive(true);
        spawnableObject.transform.position = location;
        spawnableObject.transform.rotation = rotation;

        poolDict[tag].Enqueue(spawnableObject);

        return spawnableObject;
    }
}
