using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrajectory
{
    Vector3 Direction { get; }
    void SetBulletDirecton(Vector3 direction);
}
