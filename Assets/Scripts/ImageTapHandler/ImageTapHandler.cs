using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageTapHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event System.Action onImagePressedDown;
    public event System.Action<bool> onImagePressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        onImagePressedDown?.Invoke();
        onImagePressed?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onImagePressed?.Invoke(false);
    }
}
