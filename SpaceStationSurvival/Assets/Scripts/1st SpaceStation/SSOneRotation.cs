using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSOneRotation : MonoBehaviour
{
    public GameObject OuterCircle;

    // Update is called once per frame
    void Update()
    {
        OuterCircle.transform.Rotate(5 * Time.deltaTime, 5 * Time.deltaTime, 5 * Time.deltaTime); //rotates 5 degrees per second around every axis
    }
}
