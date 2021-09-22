using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffectBehaviour : MonoBehaviour
{
    [Range(0f,5f)]
    [SerializeField] float parallaxSpeed;
    Material material;
    static readonly int materialID = Shader.PropertyToID("_MainTex");
    Vector2 offsetValue;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        offsetValue.y -= parallaxSpeed * Time.deltaTime;
        material.SetTextureOffset(materialID, offsetValue);

    }
}
