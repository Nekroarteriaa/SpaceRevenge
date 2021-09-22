using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Collections;

public class ObjectPoolManager : MonoBehaviour
{
    public event Action onPoolReady;
    public event Action<GameObject> onPoolableObjectGetted;
    public event Action<GameObject> onPoolableObjectReturned;

    [SerializeField]
    List<PoolableObject> poolableObjects;
    [SerializeField]
    int poolInflation;
    Dictionary<GameObject, Queue<GameObject>> pool = new Dictionary<GameObject, Queue<GameObject>>();
    List<GameObject> keys = new List<GameObject>();
    const string CONTAINERSUFFIX = "Container";

    void Awake()
    {
        Init();
    }

    private void Start()
    {
        OnPoolReady();
    }

    private void Init()
    {
        foreach (var item in poolableObjects)
        {
            var objectQueue = new Queue<GameObject>();
            var goContainer = new GameObject(item.GetPoolableObjectName + CONTAINERSUFFIX);
            goContainer.transform.SetParent(this.transform);

            InflatePool(item.PoolableGO, item.PoolSize, objectQueue, goContainer);

            keys.Add(goContainer);

        }
    }


    public GameObject GetPoolableObject(GameObject poolableGO, Transform newContainer)
    {
        var keyValue = keys.SingleOrDefault(x => x.name == poolableGO.name + CONTAINERSUFFIX);

        if (pool[keyValue].Count <= 0)
        {
            InflatePool(poolableGO, poolInflation, pool[keyValue], keyValue);
        }

        var objToSpawn = pool[keyValue].Dequeue();
        objToSpawn.transform.SetParent(newContainer);

        OnPoolableObjectGetted(objToSpawn);
        return objToSpawn;
    }

    public void ReturnPoolableObject(GameObject poolableGO)
    {
        OnPoolableObjectReturned(poolableGO);

        poolableGO.SetActive(false);
        poolableGO.transform.position = Vector3.zero;
        var keyValue = keys.SingleOrDefault(x => x.name == poolableGO.name + CONTAINERSUFFIX);
        pool[keyValue].Enqueue(poolableGO);
        poolableGO.transform.SetParent(keyValue.transform);

    }

    public bool IsContainedInPool(GameObject posiblePoolableObject)
    {
        var keyValue = keys.SingleOrDefault(x => x.name == posiblePoolableObject.name + CONTAINERSUFFIX);
        return (keyValue != null);
    }


    private void InflatePool(GameObject item, int poolSize, Queue<GameObject> objectQueue, GameObject goContainer)
    {
        for (var i = 0; i < poolSize; i++)
        {
            var poolableObject = GameObject.Instantiate(item, Vector3.zero, Quaternion.identity, goContainer.transform);
            poolableObject.name = item.name;
            poolableObject.SetActive(false);
            objectQueue.Enqueue(poolableObject);
        }
        if (pool.ContainsKey(goContainer))
            return;

        pool.Add(goContainer, objectQueue);
    }

    void OnPoolableObjectGetted(GameObject poolableObjectGetted)
    {
        onPoolableObjectGetted?.Invoke(poolableObjectGetted);
    }
    
    void OnPoolableObjectReturned(GameObject poolableObjectReturned)
    {
        onPoolableObjectReturned?.Invoke(poolableObjectReturned);
    }

    void OnPoolReady()
    {
        onPoolReady?.Invoke();
    }

}