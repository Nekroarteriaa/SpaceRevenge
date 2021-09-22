using UnityEngine;

[RequireComponent(typeof(PoolReturnerBehaviour))]
public class HealPowerUp : MonoBehaviour
{
    [SerializeField] int healAmount;
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
        if (layerMask == (layerMask | (1 << other.gameObject.layer)))
        {
            if (other.transform.root.TryGetComponent(out IHeal healthBehaviour))
                DoHeal(healthBehaviour);

            ReturnToPool();
        }
    }

    private void DoHeal(IHeal healthBehaviour)
    {
        healthBehaviour.DoHeal(healAmount);
    }

    public void ReturnToPool()
    {
        poolReturner.ReturnToPool();
    }
}
