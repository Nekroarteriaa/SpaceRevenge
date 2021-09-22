using UnityEngine;

public class EnemyFireRateController : MonoBehaviour
{
    ITurret[] turrets;

    private void Awake()
    {
        turrets = GetComponentsInChildren<ITurret>();
        var fireRateRange = Random.Range(1.4f, 2f);
        for (int i = 0; i < turrets.Length; i++)
        {
            turrets[i].SetFireRate(fireRateRange);
        }
    }

}
