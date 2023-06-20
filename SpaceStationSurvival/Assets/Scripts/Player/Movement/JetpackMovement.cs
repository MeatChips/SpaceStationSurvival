using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera myCamera;

    //[SerializeField] private float JetpackFuel = 300;

    [Header("Movement")]
    private float flySpeed = 8;
    private float flyFastSpeed = 16;
    private float levitationSpeed = 8;
    [SerializeField] private float moveSpeed;

    //private Quaternion originalRotation;
    //private float rotationResetSpeed = .01f;

    [Header("Crouching")]
    [SerializeField] private float playerHeight;
    [SerializeField] private bool hittingRoof;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("Player is missing a CharacterController component");
        }

        //originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        myCamera.transform.position = new Vector3(characterController.bounds.center.x, characterController.bounds.max.y - .5f, characterController.bounds.center.z);

        JetpackMove();
        JetpackFly();
        Movement();

        //JetpackRotate();
    }

    public void JetpackFly()
    {
        moveDirection = Vector3.up * levitationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(moveDirection);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.Move(-moveDirection);
        }
    }

    public void JetpackMove()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 flyMove = transform.right * x + transform.forward * z;
        characterController.Move(flyMove);
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = flyFastSpeed;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            StartCrouch();
            moveSpeed = flySpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            StopCrouch();
            moveSpeed = flySpeed;
        }
        else
        {
            moveSpeed = flySpeed;
        }
    }

    public void StartCrouch()
    {
        characterController.height = Mathf.Lerp(characterController.height, 2.2f, 7 * Time.deltaTime);
    }

    public void StopCrouch()
    {
        // Checking if the player is hitting the roof
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(myCamera.transform.position, transform.TransformDirection(Vector3.up), out hit, 1))
        {
            Debug.DrawRay(myCamera.transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            hittingRoof = true;
        }
        else
        {
            Debug.DrawRay(myCamera.transform.position, transform.TransformDirection(Vector3.up) * 2, Color.white);
            //Debug.Log("Did not Hit");
            hittingRoof = false;
        }

        if (!hittingRoof)
        {
            characterController.height = Mathf.Lerp(characterController.height, 3.7f, 7 * Time.deltaTime);
        }
        else if (hittingRoof)
        {
            //Debug.Log("CANNOT STAND UP");
        }
    }

    //public void JetpackRotate()
    //{
    //    if (Input.GetKey(KeyCode.Q))
    //    {
    //        transform.Rotate(new Vector3(0, 0, 20) * Time.deltaTime);
    //    }
    //
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        transform.Rotate(new Vector3(0, 0, -20) * Time.deltaTime);
    //    }
    //
    //    if (Input.GetKey(KeyCode.R))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.time * rotationResetSpeed);
    //    }
    //}
}
