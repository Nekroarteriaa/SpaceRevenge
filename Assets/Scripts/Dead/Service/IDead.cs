using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDead
{
    event System.Action<Vector3> onDead;
    void OnDead(Vector3 explosionPosition);
}
