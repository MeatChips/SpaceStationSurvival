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

    [Header("Other Script")]
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private GameObject Player;

    public bool gM;

    void Start()
    {
        playerMovementScript = Player.GetComponent<PlayerMovement>();

        jetpackMovement.enabled = false;
        playerMovement.enabled = true;

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

            Player.GetComponent<PlayerMovement>().gravity = 0f;
            Player.GetComponent<PlayerMovement>().gravityTwo = 0f;

            gM = false;
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

            Player.GetComponent<PlayerMovement>().gravity = 30;
            Player.GetComponent<PlayerMovement>().gravityTwo = -2f;

            gM = true;
        }


        if (Input.GetKeyUp(KeyCode.Alpha1) && !Player.GetComponent<PlayerMovement>().isFalling)
        {
            Player.GetComponent<PlayerMovement>().isFalling = true;
        }
    }
}
