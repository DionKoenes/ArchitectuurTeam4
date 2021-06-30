using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{
    [SerializeField]
    private float amplitude = 1;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float turnSpeedX = 1f;
    [SerializeField]
    private float turnSpeedY = 1f;
    [SerializeField]
    private float turnSpeedZ = 1f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * speed) * amplitude, 0.0f);

        transform.Rotate(turnSpeedX, turnSpeedY, turnSpeedZ);
    }
}
