using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int DamageAmount => damageAmount;

    [SerializeField] int damageAmount;
    [SerializeField] LayerMask layerMask;
    PoolReturnerBehaviour poolReturner;
    private void Awake()
    {
        poolReturner = GetComponent<PoolReturnerBehaviour>();
    }


    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.name);
        if (layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            if (other.transform.root.TryGetComponent(out IDamage healthBehaviour))
                DealDamage(healthBehaviour);

            
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
