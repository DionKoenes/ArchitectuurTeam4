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
    private float turnSpeed = 1;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * speed) * amplitude, 0.0f);

        transform.Rotate(0, turnSpeed, 0);
    }
}
