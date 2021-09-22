using System;
using UnityEngine;

[RequireComponent(typeof(PoolReturnerBehaviour))]
public class BulletDamage : MonoBehaviour, IBulletDamage
{
    public int DamageAmount => damageAmount;

    [SerializeField] int damageAmount;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float lifeTime;
    PoolReturnerBehaviour poolReturner;
    private void Awake()
    {
        poolReturner = GetComponent<PoolReturnerBehaviour>();
    }

    private void OnEnable()
    {
        poolReturner.WaitAndReturnToPool(lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            if (other.transform.root.TryGetComponent(out IDamage healthBehaviour))
                DealDamage(healthBehaviour);

            else
            other.GetComponent<BulletDamage>().BulletReturnToPool();
            
            BulletReturnToPool();
        }
    }

    public void DealDamage(IDamage damage)
    {
        damage.DoDamage(DamageAmount, transform.position);
    }

    public void BulletReturnToPool()
    {
        poolReturner.ReturnToPool();
    }

}
