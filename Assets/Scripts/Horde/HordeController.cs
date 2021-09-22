using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeController : MonoBehaviour
{
    public int CurrentHorde => currentHorde;
    public event System.Action onHordeFinished;
    [SerializeField] List<int> hordesThatTriggersCinematics;
    CinematicController cinematicController;
    HordeBehaviour hordeBehaviour;
    EnemiesSpawnerBehaviour enemiesSpawnerBehaviour;
    int currentHorde;
    int previousHordeCinematicPlayed = -1;

    private void Awake()
    {
        cinematicController = FindObjectOfType<CinematicController>();
        hordeBehaviour = GetComponent<HordeBehaviour>();
        enemiesSpawnerBehaviour = GetComponent<EnemiesSpawnerBehaviour>();
    }

    private void OnEnable()
    {
        cinematicController.onStopCinematic += OnStopCinematic;
        enemiesSpawnerBehaviour.onSpawnedEnemiesRemoved += OnSpawnedEnemiesRemoved;
    }

    private void OnDisable()
    {
        cinematicController.onStopCinematic -= OnStopCinematic;
        enemiesSpawnerBehaviour.onSpawnedEnemiesRemoved -= OnSpawnedEnemiesRemoved;
    }

    private void OnSpawnedEnemiesRemoved(int remainingEnemies)
    {
        OnHordeFinished();

        if (remainingEnemies <= 0)
            PlayCinematicIfNeeded();

        OnStopCinematic();

    }

    private void OnStopCinematic()
    {
        if (enemiesSpawnerBehaviour.HasEnemiesOnScene() || currentHorde >= hordeBehaviour.HordeSize || cinematicController.IsPlayingCinematic) return;
        StartCoroutine(DoNextHorde());
    }

    IEnumerator DoNextHorde()
    {
        if (hordeBehaviour.ActivateHordeWithEnemies(currentHorde))
        {
            cinematicController.ActivateMoveEnemyAndPlayerCinematicComponent();

        }
        yield return new WaitForSeconds(hordeBehaviour.CurrentHordeTimer(currentHorde));
        SpawnHorde();
        PlayCinematicIfNeeded();
    }

    private void PlayCinematicIfNeeded()
    {
        if (!hordesThatTriggersCinematics.Contains(currentHorde)) return;
        if (previousHordeCinematicPlayed == currentHorde) return;
        if (!hordeBehaviour.ActivateHordeWithEnemies(currentHorde - 1) && enemiesSpawnerBehaviour.HasEnemiesOnScene()) return;
        cinematicController.PlayCinematic();
        previousHordeCinematicPlayed = currentHorde;
    }

    void SpawnHorde()
    {
        hordeBehaviour.SpawnHorde(currentHorde);
        currentHorde++;
    }

    
    void OnHordeFinished()
    {
        onHordeFinished?.Invoke();
    }
    
    

}
