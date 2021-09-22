using System.Collections;
using UnityEngine;

public abstract class CinematicBehaviour : MonoBehaviour
{
    [SerializeField] protected Conversation conversation;
    protected DialogDisplay dialogDisplay;
    protected PlayerMovementController playerMovement;

    protected virtual void Awake()
    {
        dialogDisplay = FindObjectOfType<DialogDisplay>();
        playerMovement = FindObjectOfType<PlayerMovementController>();
    }

    public void BeginCinematicBehaviour()
    {
        DoCinematicBehaviour();
    }

    protected abstract void DoCinematicBehaviour();

    protected virtual void InjectConversation(DialogDisplay dialogDisplay, Conversation conversation)
    {
        dialogDisplay.InjectConversation(conversation);
    }

    protected IEnumerator MovePlayerShipToHome(float animationSpeed)
    {
        var moveFX = playerMovement.GetComponent<MovementFX>();
        playerMovement.enabled = false;
        while (playerMovement.transform.position != Vector3.zero)
        {
            moveFX.PlayFX();
            yield return null;
            playerMovement.transform.position = Vector3.MoveTowards(playerMovement.transform.position, Vector3.zero, Time.deltaTime * animationSpeed);
        }
        ActivateCinematic(moveFX);
    }

    protected IEnumerator MovePlayerShipToHome(float animationSpeed, Vector3 newPosition)
    {
        var moveFX = playerMovement.GetComponent<MovementFX>();
        playerMovement.enabled = false;
        while (playerMovement.transform.position != newPosition)
        {
            moveFX.PlayFX();
            yield return null;
            playerMovement.transform.position = Vector3.MoveTowards(playerMovement.transform.position, newPosition, Time.deltaTime * animationSpeed);
        }
        ActivateCinematic(moveFX);
    }

    protected virtual void ActivateCinematic(MovementFX moveFX)
    {
        InjectConversation(dialogDisplay, conversation);
        moveFX.StopFX();
        playerMovement.enabled = true;
    }


    public virtual void SetNewConversation(Conversation newConversation)
    {
        conversation = newConversation;
    }
}
