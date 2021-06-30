using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Camera playerCam;
    private GameObject endgameText;
    private GameObject begingameText;
    private GameObject finishedText;

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
        endgameText = GameObject.Find("Endgame_text");
        begingameText = GameObject.Find("Begingame_text");
        finishedText = GameObject.Find("Finished_text");
        begingameText.SetActive(false);
        endgameText.SetActive(false);
        finishedText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        FinishGame();
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
    public void FinishGame()
    {
        RaycastHit ray;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out ray, 2))
        {
            if (ray.transform.CompareTag("EndGame"))
            {
                if (keyFragments == 5)
                {
                    endgameText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        finishedText.SetActive(true);
                    }

                }
                if (keyFragments < 5)
                {
                    begingameText.SetActive(true);
                }
            }
        }
        if (ray.transform == null || ray.transform.tag != "EndGame")
        {
            endgameText.SetActive(false);
            begingameText.SetActive(false);
       }
    }
}
