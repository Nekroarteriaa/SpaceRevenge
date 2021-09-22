using System.Collections;

public class MovementFX : ParticlesFXController
{
    ShipMovementController shipMovement;

    private void Awake()
    {
        shipMovement = GetComponent<ShipMovementController>();
    }

    private void OnEnable()
    {
        shipMovement.onMovement += ParticlesFX;
    }

    private void OnDisable()
    {
        shipMovement.onMovement -= ParticlesFX;
    }

    protected override void DoPlayFX()
    {
        ParticlesFX(true);
    }

    public override void StopFX()
    {
        ParticlesFX(false);
    }
}
