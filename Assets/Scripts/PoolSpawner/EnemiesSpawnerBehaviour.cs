using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnerBehaviour : MonoBehaviour
{
    public event System.Action<int> onSpawnedEnemiesRemoved;
    //[SerializeField] List<GameObject> enemyPrefabs;    
    HashSet<GameObject> spawnedEnemies;
    ObjectPoolManager poolManager;
    
    private void Awake()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
        spawnedEnemies = new HashSet<GameObject>();
    }

    private void OnEnable()
    {
        poolManager.onPoolableObjectReturned += OnPoolableObjectReturned;
    }
    private void OnDisable()
    {
        poolManager.onPoolableObjectReturned -= OnPoolableObjectReturned;
    }

    private void OnPoolableObjectReturned(GameObject poolableObject)
    {
        
        if(!spawnedEnemies.Contains(poolableObject)) return;
        spawnedEnemies.Remove(poolableObject);
        OnSpawnedEnemiesRemoved(spawnedEnemies.Count);
    }

    public void SpawnEnemyFromPoolReady(Vector3 spawningPosition, GameObject enemyPrefab)
    {
        //GameObject selectedEnemyPrefab = (enemyPrefab == null) ? enemyPrefabs[Random.Range(0, enemyPrefabs.Count)] : enemyPrefab;
        var go = poolManager.GetPoolableObject(enemyPrefab, null);
        go.transform.position = spawningPosition;
        go.SetActive(true);
        //if(go.TryGetComponent(out EnemyMovementController movController))
        //{
        //    movController.enabled = true;
        //}
        spawnedEnemies.Add(go);
    }

    void OnSpawnedEnemiesRemoved(int remainingEnemies)
    {
        onSpawnedEnemiesRemoved?.Invoke(remainingEnemies);
    }

    public bool HasEnemiesOnScene()
    {
        return (spawnedEnemies.Count > 0);
    }
}
