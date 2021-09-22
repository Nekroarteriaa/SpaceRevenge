using UnityEngine;

[System.Serializable]
public class PoolableObject
{
    [SerializeField]
    GameObject poolableObject;
    [SerializeField]
    int poolSize;

    public GameObject PoolableGO => poolableObject;
    public int PoolSize => poolSize;
    public string GetPoolableObjectName => poolableObject.name;

}