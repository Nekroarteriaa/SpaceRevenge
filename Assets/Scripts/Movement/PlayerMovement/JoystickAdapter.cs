using UnityEngine;

public class JoystickAdapter : MonoBehaviour, IMovementInput
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    [SerializeField] Joystick joystick;
    CinematicController cinematicController;
    bool isPlayingCinematic;
    private void Awake()
    {
        cinematicController = FindObjectOfType<CinematicController>();
    }

    private void OnEnable()
    {
        cinematicController.onPlayCinematic += OnPlayCinematic;
        cinematicController.onStopCinematic += OnStopCinematic;
    }

    private void OnDisable()
    {
        cinematicController.onPlayCinematic -= OnPlayCinematic;
        cinematicController.onStopCinematic -= OnStopCinematic;
    }

    private void Update()
    {
        if (isPlayingCinematic)
        {
            Vertical = 0;
            Horizontal = 0;
            return;
        }
        Vertical = joystick.Vertical;
        Horizontal = joystick.Horizontal;
    }

    public void DestroyJoystick()
    {
        Destroy(joystick.gameObject);
    }

    private void OnPlayCinematic()
    {
        isPlayingCinematic = true;
    }
    private void OnStopCinematic()
    {
        isPlayingCinematic = false;
    }

    
}
