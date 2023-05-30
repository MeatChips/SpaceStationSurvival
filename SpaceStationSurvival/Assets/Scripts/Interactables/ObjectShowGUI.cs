using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShowGUI : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public string message;
    bool showGui;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") showGui = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") showGui = false;
    }

    void OnGUI()
    {
        if (showGui)
        {
            GUI.Box(new Rect(Screen.width / 2.5f, Screen.height / 2, 300, 30), message);
        }
    }
    void Update()
    {
        if (showGui && Input.GetKeyDown(KeyCode.E))
        {
            if(message.Contains("restore"))
            {
                playerStats.RestoreHealth(100); //Do some stuff
                Destroy(gameObject); //Remove the item
            }

            if (message.Contains("drink"))
            {
                playerStats.RestoreThirst(100); //Do some stuff
                Destroy(gameObject); //Remove the item
            }

            if (message.Contains("eat"))
            {
                playerStats.RestoreHunger(100); //Do some stuff
                Destroy(gameObject); //Remove the item
            }

            if (message.Contains("breath"))
            {
                playerStats.RestoreOxygen(100); //Do some stuff
                Destroy(gameObject); //Remove the item
            }
        }
    }
}
