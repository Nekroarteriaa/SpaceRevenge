using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturnerBehaviour : MonoBehaviour
{
    ObjectPoolManager poolManager;

    private void Awake()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    public void ReturnToPool()
    {
        poolManager.ReturnPoolableObject(gameObject);
    }

    public bool IsContainedInPool()
    {
        return poolManager.IsContainedInPool(gameObject);
    }

    public void WaitAndReturnToPool(float timeToWait)
    {
        StartCoroutine(WaitBeforeReturningToPool(timeToWait));
    }
    IEnumerator WaitBeforeReturningToPool(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait + .2f);
        ReturnToPool();
    }
}
