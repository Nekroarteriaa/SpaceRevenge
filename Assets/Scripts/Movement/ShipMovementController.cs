using UnityEngine;

public abstract class ShipMovementController : MonoBehaviour
{
    public event System.Action<bool> onMovement;
    protected bool IsShipMoving => direction.x != 0 || direction.y != 0;
    protected IMovement movementBehaviour;
    IMovementInput movementInput;
    Vector3 direction;
    protected virtual void Awake()
    {
        movementBehaviour = GetComponent<IMovement>();
        InputInjection();
    }


    protected virtual void Update()
    {
        MoveShip();
    }
    protected void InputDependencyInjection(IMovementInput movementInput)
    {
        this.movementInput = movementInput;
    }

    protected abstract void InputInjection();

    private void MoveShip()
    {
        if (movementInput == null) return;
        direction = new Vector3(movementInput.Horizontal, movementInput.Vertical, 0);
        movementBehaviour.Move(direction.normalized);
        ScreenLimits();
    }

    protected virtual void ScreenLimits()
    {

    }

    protected void OnMovement(bool isShipMoving)
    {
        onMovement?.Invoke(isShipMoving);
    }
}