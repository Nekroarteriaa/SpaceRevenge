using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurret
{
    void Attack(Vector3 position, Vector3 direction);
    bool CanFire();

    void SetNextFireTime();

    void SetFireRate(float newRate);

    void SetBullet(BulletTrajectoryAdapter newBullet);

}
