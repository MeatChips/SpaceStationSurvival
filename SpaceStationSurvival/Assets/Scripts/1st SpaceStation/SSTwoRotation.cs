using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTwoRotation : MonoBehaviour
{
    public GameObject SolarPanel;

    // Update is called once per frame
    void Update()
    {
        SolarPanel.transform.Rotate(0, 0, 5 * Time.deltaTime); //rotates 5 degrees per second around z axis
    }
}
