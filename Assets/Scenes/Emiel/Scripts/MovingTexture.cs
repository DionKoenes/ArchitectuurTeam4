using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTexture : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float offsetX;
    private Renderer render;
    void Start()
    {
        scrollSpeed = 1;
        offsetX = -2;
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetX += scrollSpeed * Time.deltaTime;
        render.material.mainTextureOffset = new Vector3(0f, offsetX, 1f);
    }
}
