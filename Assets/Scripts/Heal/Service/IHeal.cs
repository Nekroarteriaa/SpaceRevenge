using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeal
{
    event System.Action onHeal;
    event System.Action<int> onHealAmountReceived;
    void DoHeal(int healAmount);
}
