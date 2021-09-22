using System.Collections.Generic;
using UnityEngine;

public class DeadCollisionFXSpawner : CollisionFXSpawner
{
    HashSet<IDead> deadComponents;

    protected override void Awake()
    {
        base.Awake();
        deadComponents = new HashSet<IDead>();
    }
    protected override void OnPoolableObjectGetted(GameObject poolableObject)
    {
        if (!poolableObject.TryGetComponent(out IDead deadComponent)) return;
        if (deadComponents.Contains(deadComponent)) return;
        deadComponent.onDead += ShowParticlesFX;
        deadComponents.Add(deadComponent);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (var item in deadComponents)
        {
            item.onDead -= ShowParticlesFX;
        }
        deadComponents.Clear();
    }
}
