using UnityEngine;

public interface IDamageDealer
{
    int DamageAmount { get; }
    void DealDamage(IDamage damage);
}
