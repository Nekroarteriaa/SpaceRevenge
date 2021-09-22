using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolReturnerBehaviour))]
public class DamageFX : ParticlesFXController
{
    PoolReturnerBehaviour poolReturner;
    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        poolReturner = FindObjectOfType<PoolReturnerBehaviour>();
    }

    protected override void DoPlayFX()
    {
        base.DoPlayFX();
        poolReturner.WaitAndReturnToPool(particleSystem.main.duration);
    }

   

}
