using UnityEngine;

public interface IHealth 
{
    int CurrentHealth { get; }
    int MaxHealth { get; }
}

public interface IDamage
{
    public event System.Action<Vector3> onDamageReceived;
    public event System.Action<int> onDamageAmountReceived;
    void DoDamage(int damageAmount, Vector3 damagePoint);
}

//public interface I
//{

//}
