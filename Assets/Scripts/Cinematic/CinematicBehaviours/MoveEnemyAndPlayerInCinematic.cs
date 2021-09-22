using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyAndPlayerInCinematic : CinematicBehaviour
{
    [SerializeField] float animationSpeed;
    [SerializeField] float yOffset;
    [SerializeField] Vector3 newPlayerPosition;
    ObjectPoolManager poolManager;
    EnemyMovementController enemyMovement;
    protected override void Awake()
    {
        base.Awake();
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    private void OnEnable()
    {
        poolManager.onPoolableObjectGetted += OnPoolableObjectGetted;
    }

    private void OnDisable()
    {
        poolManager.onPoolableObjectGetted -= OnPoolableObjectGetted;
    }

    private void OnPoolableObjectGetted(GameObject enemy)
    {
        if (enemy.TryGetComponent(out EnemyMovementController enemyMovementController))
        {
            enemyMovement = enemyMovementController;
            enemyMovement.SetShootingDelay(2f);
            enemyMovement.enabled = false;

        }


    }

    protected override void DoCinematicBehaviour()
    {
        var finalPosition = enemyMovement.transform.position;
        finalPosition.y -= yOffset;
        StartCoroutine(ShipInterpolation(enemyMovement.transform, finalPosition));
    }

    IEnumerator ShipInterpolation(Transform enemyTransform, Vector3 finalPosition)
    {
        playerMovement.enabled = false;
        float elapsedTime = 0f;
        float percentageComplete = 0f;
        while (enemyTransform.position != finalPosition)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / animationSpeed;
            enemyTransform.position = Vector3.Lerp(enemyTransform.position, finalPosition, percentageComplete);
        }
        
        yield return StartCoroutine(MovePlayerShipToHome(animationSpeed, newPlayerPosition));

        InjectConversation(dialogDisplay, conversation);
        playerMovement.enabled = true;
        enemyMovement.enabled = true;
        enemyMovement.SetVerticalValue(0);
        enemyMovement.MoveAfterCinematic(false);
        

    }

    protected override void ActivateCinematic(MovementFX moveFX)
    {
        moveFX.StopFX();
        playerMovement.enabled = true;
    }

    
}
