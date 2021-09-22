using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    IMovement movementBehaviour;
    ITrajectory trajectory;
    void Awake()
    {
        movementBehaviour = GetComponent<IMovement>();
        trajectory = GetComponent<ITrajectory>();
    }

    void Update()
    {
        movementBehaviour.Move(trajectory.Direction);
    }
}
