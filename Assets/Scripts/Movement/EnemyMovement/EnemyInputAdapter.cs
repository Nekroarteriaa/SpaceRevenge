using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputAdapter : MonoBehaviour,IEnemyMovement
{
    public float Horizontal => horizontal;

    public float Vertical => vertical;

    [SerializeField] float horizontal;
    [SerializeField] float vertical;

    public void SetHorizontalValue(float newValue)
    {
        horizontal = newValue;
    }

    public void SetVerticalValue(float newValue)
    {
        vertical = newValue;
    }
}
