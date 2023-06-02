using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSwitcher : MonoBehaviour
{
    [Header("Movement Systems")]
    public PlayerMovement playerMovement;
    public JetpackMovement jetpackMovement;

    [Header("Images")]
    public RawImage playerIcon;
    public RawImage jetpackIcon;

    public ParticleSystem ExhaustParticleLeft;
    public ParticleSystem ExhaustParticleRight;

    void Start()
    {
        jetpackIcon.enabled = false;
        playerIcon.enabled = true;

        ExhaustParticleLeft.Stop();
        ExhaustParticleRight.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            jetpackMovement.enabled = true;
            playerMovement.enabled = false;
            // Jetpack movement
            jetpackIcon.enabled = true;
            playerIcon.enabled = false;

            ExhaustParticleLeft.Play();
            ExhaustParticleRight.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            jetpackMovement.enabled = false;
            playerMovement.enabled = true;
            // Ground movement
            jetpackIcon.enabled = false;
            playerIcon.enabled = true;

            ExhaustParticleLeft.Stop();
            ExhaustParticleRight.Stop();
        }
    }
}
