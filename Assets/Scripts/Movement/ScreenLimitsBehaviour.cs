using UnityEngine;

public class ScreenLimitsBehaviour : MonoBehaviour, IScreenLimits
{
    Camera cam;
    Vector3 viewportPoint;
    private void Awake()
    {
        cam = Camera.main;
        
    }

    public void MovementLimits()
    {
        viewportPoint = cam.WorldToViewportPoint(transform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, 0.03f, 0.97f);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, 0.03f, 0.97f);
        transform.position = cam.ViewportToWorldPoint(viewportPoint);
    }

    public void SetNewCameraLimits(Camera newCam)
    {
        cam = newCam;
    }
}
