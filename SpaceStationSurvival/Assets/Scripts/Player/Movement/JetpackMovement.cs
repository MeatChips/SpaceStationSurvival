using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    //[SerializeField] private float JetpackFuel = 300;

    private float flySpeed = 10;
    private float levitationSpeed = 10;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("Player is missing a CharacterController component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        JetpackMove();

        JetpackFly();

        //JetpackRotate();
    }

    public void JetpackFly()
    {
        moveDirection = Vector3.up * levitationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(moveDirection);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(-moveDirection);
        }
    }

    public void JetpackMove()
    {
        float x = Input.GetAxis("Horizontal") * flySpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * flySpeed * Time.deltaTime;
        Vector3 flyMove = transform.right * x + transform.forward * z;
        characterController.Move(flyMove);
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
    //}
}
