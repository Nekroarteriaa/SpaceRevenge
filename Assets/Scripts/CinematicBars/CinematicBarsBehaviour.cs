using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicBarsBehaviour : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] ImageTapHandler tapHandler;
    [SerializeField] Transform topBar;
    [SerializeField] Transform bottomBar;
    [SerializeField] float yOffset;
    [SerializeField] float duration;
    [SerializeField] AnimationCurve curve;
    Vector3 finalPosTop;
    Vector3 finalPosBottom;
    Vector3 originalTopBarPosition;
    Vector3 originalBottomBarPosition;

    private void Awake()
    {
        originalBottomBarPosition = bottomBar.position;
        originalTopBarPosition = topBar.position;

        finalPosTop = topBar.position;
        finalPosBottom = bottomBar.position;
        finalPosTop.y -= yOffset;
        finalPosBottom.y += yOffset;
        
    }
   
    public void ShowBars()
    {
        StartCoroutine(DoInterpolation(topBar, finalPosTop));
        StartCoroutine(DoInterpolation(bottomBar, finalPosBottom));
        joystick.gameObject.SetActive(false);
        tapHandler.gameObject.SetActive(false);
    }
    public void HideBars()
    {
        StartCoroutine(DoInterpolation(topBar, originalTopBarPosition));
        StartCoroutine(DoInterpolation(bottomBar, originalBottomBarPosition));
        joystick.gameObject.SetActive(true);
        tapHandler.gameObject.SetActive(true);
    }

    IEnumerator DoInterpolation(Transform interpolationTransform , Vector3 finalPosition)
    {
        float elapsedTime = 0f;
        float percentageComplete = 0f;
        while (percentageComplete < 1)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / duration;
            interpolationTransform.position = Vector3.Lerp(interpolationTransform.position, finalPosition, percentageComplete);
        }
    }

}
