using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 roationDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(roationDirection * speed * Time.deltaTime);
    }
}
