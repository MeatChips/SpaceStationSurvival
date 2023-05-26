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
            playerStats.RestoreHealth(100); //Do some stuffs like health
            Destroy(gameObject); //Remove the item
        }
    }
}
