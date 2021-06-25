using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderErlenmyer : MonoBehaviour
{
    float scrollSpeed;
    float offsetX;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = 0.1f;
        offsetX = 0f;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offsetX -= scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = new Vector3(offsetX, offsetX, offsetX);
    }
}
