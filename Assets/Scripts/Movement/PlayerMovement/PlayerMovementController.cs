using UnityEngine;

public class PlayerMovementController : ShipMovementController
{
    [SerializeField] bool useJoystick;
    IScreenLimits screenLimits;
   
    protected override void Awake()
    {
        base.Awake();
        screenLimits = GetComponent<IScreenLimits>();
        InputInjection();
    }

   

    protected override void InputInjection()
    {
        IMovementInput movementInput = null;
        if (useJoystick)
            movementInput = GetComponent<JoystickAdapter>();
        else
        {
            movementInput = GetComponent<UnityInputAdapter>();
            var joystick = GetComponent<JoystickAdapter>();
            joystick.DestroyJoystick();
            Destroy(joystick);
        }
        InputDependencyInjection(movementInput);
    }

    protected override void ScreenLimits()
    {
        screenLimits.MovementLimits();
    }

    protected override void Update()
    {
        base.Update();
        OnMovement(IsShipMoving);

    }
}
