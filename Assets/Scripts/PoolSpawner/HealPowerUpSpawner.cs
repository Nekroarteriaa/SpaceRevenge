using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject HealPowerUpPrefab;
    IDead dead;
    ObjectPoolManager poolManager;
    private void Awake()
    {
        dead = GetComponent<IDead>();
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    private void OnEnable()
    {
        dead.onDead += OnDead;
    }

    private void OnDisable()
    {
        dead.onDead -= OnDead;
    }

    private void OnDead(Vector3 deadPosition)
    {
        var randomize = Random.Range(0f, 1f);
        if (randomize > .43f) return;
        var gO = poolManager.GetPoolableObject(HealPowerUpPrefab, null);
        gO.transform.position = deadPosition;
        gO.gameObject.SetActive(true);  
    }
}
