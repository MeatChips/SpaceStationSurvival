using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSwitcher : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public JetpackMovement jetpackMovement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            jetpackMovement.enabled = true;
            playerMovement.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            jetpackMovement.enabled = false;
            playerMovement.enabled = true;
        }
    }
}
