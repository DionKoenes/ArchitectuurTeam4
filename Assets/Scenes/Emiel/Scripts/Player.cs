using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    [SerializeField]
    private CharacterController controller;

    private float speed = 5f;
    private float runSpeed = 10f;
    private float gravity = -8.81f;
    private float jumpHeight = 3f;
    private float groundDistance = 0.4f;
    Vector3 velocity;
    private bool isGrounded;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;
    
    //Pickup
    public int keyFragments = 0;
    public AudioSource pickupSound;

    public void PlayerMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            controller.Move(move * runSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("KeyFragment"))
        {
            keyFragments++;
            Destroy(col.gameObject);
            pickupSound.Play();
        }
    }
}
