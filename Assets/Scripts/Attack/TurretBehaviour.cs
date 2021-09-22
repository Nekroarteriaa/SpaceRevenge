using UnityEngine;

public class TurretBehaviour : MonoBehaviour, ITurret
{
    [SerializeField] BulletTrajectoryAdapter bullet;
    [SerializeField] float fireRate;
    float nextTimeFire;
    ObjectPoolManager poolManager;

    private void Awake()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }


    public void Attack(Vector3 position, Vector3 direction)
    {
        var newBullet = poolManager.GetPoolableObject(bullet.gameObject, null);
        newBullet.transform.position = transform.position;
        newBullet.SetActive(true);
        newBullet.GetComponent<BulletTrajectoryAdapter>().SetBulletDirecton(direction);

    }

    public bool CanFire()
    {
        return Time.time >= nextTimeFire;
    }

    public void SetFireRate(float newRate)
    {
        fireRate = newRate;
    }

    public void SetNextFireTime()
    {
        nextTimeFire = Time.time + fireRate;
    }

    public void SetBullet(BulletTrajectoryAdapter newBullet)
    {
        bullet = newBullet;
    }
}
