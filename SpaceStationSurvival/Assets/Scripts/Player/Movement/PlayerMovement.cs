using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera myCamera;

    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    private float walkSpeed = 12f;
    private float sprintSpeed = 20f;
    private float crouchSpeed = 6f;

    [Header("Jumping/Gravity/Diving Parameters")]
    private float gravity = -30f;
    private float jumpHeight = 2.4f;
    [SerializeField] private bool isFalling;

    [Header("GroundCheck")]
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;

    [Header("Crouching")]
    [SerializeField] private float playerHeight;
    [SerializeField] private bool hittingRoof;

    [Header("Particles")]

    Vector3 Velocity;
    bool isGrounded;

    void Start()
    {
        //groundCheck.transform.position = new Vector3(characterController.bounds.center.x, characterController.bounds.center.z, characterController.bounds.min.y);
        //playerHeight = characterController.height;

        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("Player is missing a CharacterController component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck.transform.position = new Vector3(characterController.bounds.center.x, characterController.bounds.min.y, characterController.bounds.center.z);
        myCamera.transform.position = new Vector3(characterController.bounds.center.x, characterController.bounds.max.y - .5f, characterController.bounds.center.z);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * moveSpeed * Time.deltaTime);

        Jumping();
        Movement();
        Falling();

        Velocity.y += gravity * Time.deltaTime;

        characterController.Move(Velocity * Time.deltaTime);
    }

    #region Falling
    public void Falling()
    {
        // Checking how far the player is from the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 8))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.red);
            //Debug.Log("Player is not falling");
            isFalling = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * 5, Color.red);
            //Debug.Log("Player is falling");
            isFalling = true;
        }
    }
    #endregion

    #region Movement
    public void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            StartCrouch();
            moveSpeed = crouchSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            StopCrouch();
            moveSpeed = walkSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
    #endregion

    #region Jumping
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        else if (isFalling)
        {
            Velocity.y += gravity * Time.deltaTime;
        }
    }
    #endregion

    #region Crouching
    public void StartCrouch()
    {
        characterController.height = Mathf.Lerp(characterController.height, 2.2f, 7 * Time.deltaTime);
    }

    public void StopCrouch()
    {
        // Checking if the player is hitting the roof
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            hittingRoof = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 2, Color.white);
            //Debug.Log("Did not Hit");
            hittingRoof = false;
        }

        if (!hittingRoof)
        {
            characterController.height = Mathf.Lerp(characterController.height, 3.7f, 7 * Time.deltaTime);
        }
        else
        {
            Debug.Log("CANNOT STAND UP");
        }
    }
    #endregion
}

