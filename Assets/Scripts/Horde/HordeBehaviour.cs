using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeBehaviour : MonoBehaviour
{
    public int HordeSize => hordeDictionary.Count;
    [SerializeField] List<Horde> hordes;
    Dictionary<int, List<Transform>> hordeDictionary;
    EnemiesSpawnerBehaviour enemiesSpawner;
    private void Awake()
    {
        hordeDictionary = new Dictionary<int, List<Transform>>();
        for (int i = 0; i < hordes.Count; i++)
        {
            var hordesSpawnPoints = hordes[i].SpawnPointsHorde;
            hordeDictionary.Add(i, hordesSpawnPoints);
        }
        enemiesSpawner = GetComponent<EnemiesSpawnerBehaviour>();
    }

    public float CurrentHordeTimer(int currentHorde) => hordes[currentHorde].SpawnHordeTimer;

    public void SpawnHorde(int hordeNumber)
    {
        if (hordeNumber >= hordeDictionary.Count) return;
        var hordeSpawnPoints = hordeDictionary[hordeNumber];
        for (int i = 0; i < hordeSpawnPoints.Count; i++)
        {
            enemiesSpawner.SpawnEnemyFromPoolReady(hordeSpawnPoints[i].position, hordes[hordeNumber].HordeEnemy);
        }
    }

    public bool ActivateHordeWithEnemies(int currentHorde) => hordes[currentHorde].ActivateWithEnemies;

}
