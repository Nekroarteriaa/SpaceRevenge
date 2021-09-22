using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleTurret : TurretController
{
    [SerializeField]List<BulletTrajectoryAdapter> bullets;
    EnemyMovementController enemyMovement;
    bool canStartShooting;

    protected override void DependencyInjection()
    {
        base.DependencyInjection();
        if (enemyMovement == null)
            enemyMovement = transform.root.GetComponent<EnemyMovementController>();
    }

    private void OnEnable()
    {
        DependencyInjection();

        if (enemyMovement != null)
            enemyMovement.onBeginShooting += OnBeginShooting;
    }


    private void OnDisable()
    {
        if (enemyMovement != null)
            enemyMovement.onBeginShooting -= OnBeginShooting;
    }

    private void OnBeginShooting()
    {
        if (canStartShooting) return;
        canStartShooting = true;
    }

    protected override void Fire()
    {
        if (!canStartShooting) return;
        if(CanFire())
        {
            var selectedBullet = bullets[Random.Range(0, bullets.Count)];
            SetBullet(selectedBullet);
            Shoot();
        }
    }

    
}
