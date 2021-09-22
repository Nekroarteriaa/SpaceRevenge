using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectoryAdapter : MonoBehaviour, ITrajectory
{
    public Vector3 Direction { get; private set; }
    
    public void SetBulletDirecton(Vector3 direction)
    {
        Direction = direction;
    }
}
