using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    [SerializeField] private float xMouseSensitivity = 100f;
    [SerializeField] private float yMouseSensitivity = 100f;

    [Header("Transforms")]
    [SerializeField] private Transform playerBody;

    [Header("Rotation")]
    [SerializeField] private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xMouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * yMouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
