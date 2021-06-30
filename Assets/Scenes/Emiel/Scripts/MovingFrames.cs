using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFrames : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    private float time;
    private float frameX;
    private float frameY;
    private Renderer rend;

    void Start()
    {
        scrollSpeed = 0.25f;
        time = 0f;
        frameX = 0f;
        frameY = 0f;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 20 * Time.deltaTime;

        if (time >= 2f)
        {
            frameX++;
            time = 0f;
        }
        if (frameX >= 4f)
        {
            frameX = 0f;
            frameY--;
        }
        if (frameX <= -2f)
        {
            frameX = 0f;
        }

        float offsetX = frameX * scrollSpeed;
        float offsetY = frameY * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
