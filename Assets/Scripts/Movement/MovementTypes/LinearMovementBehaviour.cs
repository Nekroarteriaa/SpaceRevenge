using UnityEngine;

public class LinearMovementBehaviour : MonoBehaviour, IMovement
{
    public float Speed => currentSpeed;

    public float MaxSpeed => maxSpeed;
    [SerializeField] float currentSpeed;
    [SerializeField] float maxSpeed;

    public void Move(Vector3 direction)
    {
        transform.position += direction * (currentSpeed * Time.deltaTime);
    }

    public void SetRandomSpeed()
    {
        currentSpeed = Random.Range(currentSpeed, maxSpeed);
    }
}
