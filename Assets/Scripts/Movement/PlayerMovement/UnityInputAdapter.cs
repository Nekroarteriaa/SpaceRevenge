using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInputAdapter : MonoBehaviour, IMovementInput
{
    public float Horizontal{ get; private set; }

    public float Vertical { get; private set; }

    private void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
    }
}
