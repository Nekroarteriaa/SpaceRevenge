using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public event System.Action onHealthBarEmpty;
    HealthBehaviour healthBehaviour;
    Image imageFill;
    private void Awake()
    {
        healthBehaviour = FindObjectOfType<HealthBehaviour>();
        imageFill = GetComponent<Image>();
        imageFill.fillAmount = 1;
    }

    private void OnEnable()
    {
        healthBehaviour.onDamageAmountReceived += OnDamageReceived;
        healthBehaviour.onHealAmountReceived += OnHealReceived;
    }


    private void OnDisable()
    {
        healthBehaviour.onDamageAmountReceived -= OnDamageReceived;
        healthBehaviour.onHealAmountReceived -= OnHealReceived;
    }
    private void OnHealReceived(int healAmount)
    {
        imageFill.fillAmount += LifeBarPercentage(healAmount);
    }

    private void OnDamageReceived(int damageAmount)
    {
        imageFill.fillAmount -= LifeBarPercentage(damageAmount);
        if (imageFill.fillAmount <= 0)
            onHealthBarEmpty?.Invoke();
    }

    float LifeBarPercentage(int damageAmount)
    {
        return (float) damageAmount / healthBehaviour.MaxHealth;
    }
}
