using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Horde
{
    public List<Transform> SpawnPointsHorde => spawnPointsHorde;
    public float SpawnHordeTimer => spawnHordeTimer;
    public bool ActivateWithEnemies => activeWithEnemies;
    public GameObject HordeEnemy =>hordeEnemies[Random.Range(0, hordeEnemies.Count)];
    public List<GameObject> HordeEnemies => hordeEnemies;
    [SerializeField] List<Transform> spawnPointsHorde;
    [SerializeField] float spawnHordeTimer;
    [SerializeField] bool activeWithEnemies;
    [SerializeField] List<GameObject> hordeEnemies;
}
