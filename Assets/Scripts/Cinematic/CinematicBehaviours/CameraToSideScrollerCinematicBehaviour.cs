using UnityEngine;
using UnityEngine.Playables;

public class CameraToSideScrollerCinematicBehaviour : CinematicBehaviour
{
    [SerializeField] float animationSpeed;
    
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void DoCinematicBehaviour()
    {
        StartCoroutine(MovePlayerShipToHome(animationSpeed));
    }

    protected override void ActivateCinematic(MovementFX moveFX)
    {
        //virtualCamOriginal.SetActive(false);
        base.ActivateCinematic(moveFX);
    }
}
