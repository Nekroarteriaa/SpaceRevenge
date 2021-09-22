using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParticles
{
    private readonly ParticleSystem particle;

    public ShipParticles(ParticleSystem particle)
    {
        this.particle = particle;
    }

    public void ParticlesFX(bool activate)
    {
        particle.gameObject.SetActive(activate);
    }
}
