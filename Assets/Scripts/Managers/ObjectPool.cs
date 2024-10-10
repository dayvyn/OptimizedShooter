using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectsToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int k = 0 ; k < objectsToPool.Length; k++)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectsToPool[k]);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
        
    }

    public GameObject GetPooledObject()
    {
        int totalPool = 30;
        for (int i = 0; i < amountToPool; i++)
        {
            int rand = Random.Range(i, totalPool);
            if (!pooledObjects[rand].activeInHierarchy)
            {
                return pooledObjects[rand];
            }
        }
        return null;
    }
}
