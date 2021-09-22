using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBarsController : MonoBehaviour
{
    CinematicController cinematicController;
    CinematicBarsBehaviour cinematicBarsBehaviour;
    

    private void Awake()
    {
        cinematicController = FindObjectOfType<CinematicController>();
        cinematicBarsBehaviour = GetComponent<CinematicBarsBehaviour>();
    }

    private void OnEnable()
    {
        cinematicController.onPlayCinematic += StartCinematic;
        cinematicController.onStopCinematic += StopCinematic;
    }

    private void OnDisable()
    {
        cinematicController.onPlayCinematic -= StartCinematic;
        cinematicController.onStopCinematic -= StopCinematic;
    }

    public void StartCinematic()
    {
        cinematicBarsBehaviour.ShowBars();
    }

    private void StopCinematic()
    {
        cinematicBarsBehaviour.HideBars();
    }

    
}
