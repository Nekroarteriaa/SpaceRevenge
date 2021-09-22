using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticlesFXController : MonoBehaviour
{
    [SerializeField] protected ParticleSystem particleSystem;

    public virtual void PlayFX()
    {
        DoPlayFX();
    }

    public virtual void StopFX()
    {
        DoStopFX();
    }

    protected void ParticlesFX(bool activate)
    {
        particleSystem.gameObject.SetActive(activate);
    }

    protected virtual void DoPlayFX()
    {
        particleSystem.Play();
    }

    protected void DoStopFX()
    {
        particleSystem.Stop();
    }
}
