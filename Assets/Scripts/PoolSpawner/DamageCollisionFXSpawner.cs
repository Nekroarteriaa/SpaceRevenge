using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollisionFXSpawner : CollisionFXSpawner
{
    HashSet<IDamage> damagesComponent;
    IDamage playerDamage;
    protected override void Awake()
    {
        base.Awake();
        damagesComponent = new HashSet<IDamage>();
        playerDamage = FindObjectOfType<HealthBehaviour>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        playerDamage.onDamageReceived += ShowParticlesFX;
    }


    protected override void OnPoolableObjectGetted(GameObject poolableObject)
    {
        if (!poolableObject.TryGetComponent(out IDamage damageComponent)) return;
        if (damagesComponent.Contains(damageComponent)) return;
        damageComponent.onDamageReceived += ShowParticlesFX;
        damagesComponent.Add(damageComponent);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        playerDamage.onDamageReceived -= ShowParticlesFX;
        foreach (var item in damagesComponent)
        {
            item.onDamageReceived -= ShowParticlesFX;
        }
        damagesComponent.Clear();
    }
}
