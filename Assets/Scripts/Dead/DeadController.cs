using UnityEngine;

[RequireComponent(typeof(PoolReturnerBehaviour))]
public class DeadController : MonoBehaviour
{
    IDead dead;
    PoolReturnerBehaviour poolReturner;
   

    private void Awake()
    {
        dead = GetComponent<IDead>();
        poolReturner = GetComponent<PoolReturnerBehaviour>();
    }

    private void OnEnable()
    {
        dead.onDead += OnDead;
    }

    private void OnDisable()
    {
        dead.onDead -= OnDead;
    }

    public void OnDead(Vector3 explosionPosition)
    {
        if (poolReturner.IsContainedInPool())
        {
            poolReturner.ReturnToPool();
            return;
        }
        
        Destroy(this.gameObject);
    }
}
