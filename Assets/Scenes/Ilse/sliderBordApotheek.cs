using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderBordApotheek : MonoBehaviour
{
    float scrollSpeed;
    float offsetX;
    Renderer rend;
    
    void Start()
    {
        scrollSpeed = 0.1f;
        offsetX = 0f;
        rend = GetComponent<Renderer>();
    }

    
    void Update()
    {
        offsetX -= scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = new Vector2(offsetX, 0f);
    }
}

