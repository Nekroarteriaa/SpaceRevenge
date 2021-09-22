using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    float Speed { get; }
    float MaxSpeed { get; }

    void Move(Vector3 direction);

    void SetRandomSpeed();
}
