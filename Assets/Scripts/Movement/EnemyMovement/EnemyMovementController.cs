using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : ShipMovementController
{
    public event Action onBeginShooting;
    [SerializeField] float limitYAxis = -25f;
    [SerializeField] float shootingDelay;
    IEnemyMovement enemyMovement;
    IDamage damage;
    CinematicController cinematicController;
    bool moveAfterCinematic = true;
    Vector3 viewportPoint;
    Camera cam;

    protected override void Awake()
    {
        base.Awake();
        InputInjection();
        damage = GetComponent<IDamage>();
        movementBehaviour.SetRandomSpeed();
        cinematicController = FindObjectOfType<CinematicController>();
        cam = Camera.main;

    }
    private void OnEnable()
    {
        cinematicController.onPlayCinematic += OnPlayCinematic;
        cinematicController.onStopCinematic += OnStopCinematic;
        enemyMovement.SetVerticalValue(-1);
        StartCoroutine(ShootingBeginDelay(shootingDelay));
    }

    private void OnDisable()
    {
        cinematicController.onStopCinematic -= OnStopCinematic;
        cinematicController.onPlayCinematic -= OnPlayCinematic;
    }

    protected override void InputInjection()
    {
        enemyMovement = GetComponent<EnemyInputAdapter>();
        InputDependencyInjection(enemyMovement);
    }

    public void SetShootingDelay(float newDelay)
    {
        shootingDelay = newDelay;
    }

    public void SetVerticalValue(int newValue)
    {
        enemyMovement.SetVerticalValue(newValue);
    }

    public void SetHorizontallValue(int newValue)
    {
        enemyMovement.SetHorizontalValue(newValue);
    }

    public void MoveAfterCinematic(bool canMove)
    {
        moveAfterCinematic = canMove;
    }

    protected override void ScreenLimits()
    {
        KillIfOutYLimits();

        viewportPoint = cam.WorldToViewportPoint(transform.position);
        if(viewportPoint.x >= .95f || viewportPoint.x <= .1f)
        {
            var newValue = (int)enemyMovement.Horizontal * -1;
            SetHorizontallValue(newValue);
        }

    }

    void KillIfOutYLimits()
    {
        if (transform.position.y > limitYAxis || damage == null) return;
            damage.DoDamage(15, transform.position);
    }

    IEnumerator ShootingBeginDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnBeginShooting();
    }    

    void OnBeginShooting()
    {
        onBeginShooting?.Invoke();
    }

    private void OnStopCinematic()
    {
        if (moveAfterCinematic)
            SetVerticalValue(-1);
    }

    private void OnPlayCinematic()
    {
        SetVerticalValue(0);
    }
}
