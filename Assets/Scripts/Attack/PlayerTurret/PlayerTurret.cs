using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : TurretController
{
    [SerializeField] ImageTapHandler imageTap;
    bool isButtonPressed;

    private void OnEnable()
    {
        imageTap.onImagePressed += OnImagePressed;
    }

    private void OnDisable()
    {
        imageTap.onImagePressed -= OnImagePressed;
    }

    private void OnImagePressed(bool buttonState)
    {
        isButtonPressed = buttonState;
    }

    protected override void Fire()
    {
        if (Input.GetKey(KeyCode.Space) && CanFire() || isButtonPressed && CanFire())
            Shoot();
    }
}
