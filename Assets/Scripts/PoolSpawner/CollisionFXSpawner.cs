using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionFXSpawner : MonoBehaviour
{
    [SerializeField] protected ParticlesFXController particlesFX;
    ObjectPoolManager poolManager;
   

    protected virtual void Awake()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    protected virtual void OnEnable()
    {
        poolManager.onPoolableObjectGetted += OnPoolableObjectGetted;
    }

    protected abstract void OnPoolableObjectGetted(GameObject poolableObject);

    protected virtual void OnDisable()
    {
        poolManager.onPoolableObjectGetted -= OnPoolableObjectGetted;
    }

    protected void ShowParticlesFX(Vector3 damagePoint)
    {
        var pooledFX = poolManager.GetPoolableObject(particlesFX.gameObject, transform);
        pooledFX.transform.position = damagePoint;
        pooledFX.SetActive(true);
        pooledFX.GetComponent<ParticlesFXController>().PlayFX();
    }
}
