using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSOneRotation : MonoBehaviour
{
    public GameObject OuterCircle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OuterCircle.transform.Rotate(5 * Time.deltaTime, 5 * Time.deltaTime, 5 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
