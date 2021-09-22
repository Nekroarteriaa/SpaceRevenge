using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretController : MonoBehaviour
{
    ITurret attackBehaviour;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        DependencyInjection();
    }

    protected virtual void DependencyInjection()
    {
        if(attackBehaviour == null)
            attackBehaviour = GetComponent<ITurret>();
    }

    
    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    protected virtual void Fire()
    {
        Shoot();
    }

    protected void Shoot()
    {
        attackBehaviour.Attack(transform.position, transform.up);
        attackBehaviour.SetNextFireTime();
    }

    protected bool CanFire() => attackBehaviour.CanFire();

    protected virtual void SetBullet(BulletTrajectoryAdapter newBullet)
    {
        attackBehaviour.SetBullet(newBullet);
    }

}



