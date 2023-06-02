using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractWithObject : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public RawImage InteractionImage;
    public TMP_Text TextUI;

    private string message;

    bool NameAcquired = false;


    // Start is called before the first frame update
    void Start()
    {
        InteractionImage.enabled = false;
        TextUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
    }

    private void GetInteractableData(string objectName)
    {
        message = objectName;
        if(message == objectName)
        {
            NameAcquired = true;
        }
    }

    private void SetTextUI()
    {
        //TextUI.text = "Press E to interact with " + message;

        if (message.Contains("Health"))
        {
            TextUI.text = "Press E to heal with the " + message;
        }

        if (message.Contains("Water"))
        {
            TextUI.text = "Press E to drink the " + message;
        }

        if (message.Contains("Spinach"))
        {
            TextUI.text = "Press E to eat the " + message;
        }

        if (message.Contains("Oxygen"))
        {
            TextUI.text = "Press E to breath from the " + message;
        }
    }

    public void ShowUI()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        float rayLength = 5f;

        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.tag == "Interactable")
            {
                GetInteractableData(hit.collider.gameObject.name);
                if (NameAcquired)
                {
                    SetTextUI();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (message.Contains("Health"))
                        {
                            playerStats.RestoreHealth(100); //Do some stuff
                            Destroy(hit.transform.gameObject); //Remove the item
                        }

                        if (message.Contains("Water"))
                        {
                            playerStats.RestoreThirst(100); //Do some stuff
                            Destroy(hit.transform.gameObject); //Remove the item
                        }

                        if (message.Contains("Spinach"))
                        {
                            playerStats.RestoreHunger(100); //Do some stuff
                            Destroy(hit.transform.gameObject); //Remove the item
                        }

                        if (message.Contains("Oxygen"))
                        {
                            playerStats.RestoreOxygen(100); //Do some stuff
                            Destroy(hit.transform.gameObject); //Remove the item
                        }
                    }
                }
                InteractionImage.enabled = true;
                TextUI.enabled = true;
            }
            else
            {
                InteractionImage.enabled = false;
                TextUI.enabled = false;
            }
        }
    }
}
