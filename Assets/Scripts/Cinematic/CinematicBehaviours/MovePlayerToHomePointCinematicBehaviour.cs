using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToHomePointCinematicBehaviour : CinematicBehaviour
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

    //IEnumerator ShipInterpolation()
    //{
    //    var moveFX = playerMovement.GetComponent<MovementFX>();
    //    playerMovement.enabled = false;
    //    while (playerMovement.transform.position != Vector3.zero)
    //    {
    //        moveFX.PlayFX();
    //        yield return null;
    //        playerMovement.transform.position = Vector3.MoveTowards(playerMovement.transform.position, Vector3.zero, Time.deltaTime * animationSpeed);
    //    }
    //    InjectConversation(dialogDisplay, conversation);
    //    moveFX.StopFX();
    //    playerMovement.enabled = true;
    //}
}
