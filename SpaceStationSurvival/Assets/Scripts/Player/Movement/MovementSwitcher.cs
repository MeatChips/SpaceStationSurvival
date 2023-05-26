using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSwitcher : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public JetpackMovement jetpackMovement;

    public RawImage playerIcon;
    public RawImage jetpackIcon;

    void Start()
    {
        jetpackIcon.enabled = false;
        playerIcon.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            jetpackMovement.enabled = true;
            playerMovement.enabled = false;

            jetpackIcon.enabled = true;
            playerIcon.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            jetpackMovement.enabled = false;
            playerMovement.enabled = true;

            jetpackIcon.enabled = false;
            playerIcon.enabled = true;
        }
    }
}
