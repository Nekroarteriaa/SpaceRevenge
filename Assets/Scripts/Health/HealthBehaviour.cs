using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IHealth, IDamage, IDead, IHeal
{
 
    public event Action<Vector3> onDead;
    
    public event Action<Vector3> onDamageReceived;
    public event Action<int> onDamageAmountReceived;

    public event Action onHeal;
    public event Action<int> onHealAmountReceived;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    [SerializeField]
    int maxHealth;
    int currentHealth;
    AudioSource deadSFX;

    private void Awake()
    {
        currentHealth = maxHealth;
        deadSFX = GetComponent<AudioSource>();
    }
    public void DoDamage(int damageAmount, Vector3 damagePoint)
    {
        ApplyDamage(damageAmount);
        if (currentHealth <= 0)
        {
            OnDead(transform.position);
            return;
        }
        OnDamageReceived(damagePoint);
    }

    protected virtual void ApplyDamage(int damageAmount)
    {
        currentHealth = Math.Max(currentHealth - damageAmount, 0);
        deadSFX.pitch = UnityEngine.Random.Range(.6f, 1.2f);
        if(!deadSFX.isPlaying)
        {
            deadSFX.Play();
        }
        onDamageAmountReceived?.Invoke(damageAmount);
    }

    public void OnDead(Vector3 explosionPosition)
    {
        onDead?.Invoke(explosionPosition);
    }

    void OnDamageReceived(Vector3 damagePoint)
    {
        onDamageReceived?.Invoke(damagePoint);
    }

    public void DoHeal(int healAmount)
    {
        currentHealth = Math.Min(currentHealth + healAmount, maxHealth);
        OnHealAmount(healAmount);
    }

    void OnHealAmount(int healAmount)
    {
        onHealAmountReceived?.Invoke(healAmount);
        onHeal?.Invoke();
    }
}
