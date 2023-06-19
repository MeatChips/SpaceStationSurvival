using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float timeOn;
    public float timeOff;
    private float changeTime = 0f;

    [SerializeField] private Light lampLight;

    void Start()
    {

    }

    void Update()
    {
        timeOn = Random.Range(0f, 0.3f);
        timeOff = Random.Range(0.3f, 0.6f);

        if (Time.time > changeTime)
        {
            lampLight.enabled = !lampLight.enabled;
            if (lampLight.enabled)
            {
                changeTime = Time.time + timeOn;
            }
            else
            {
                changeTime = Time.time + timeOff;
            }
        }

        //if (Random.value > .3) //a random chance
        //{
        //    if (lampLight.enabled == true) //if the light is on...
        //    {
        //        lampLight.enabled = false; //turn it off
        //    }
        //    else
        //    {
        //        lampLight.enabled = true; //turn it on
        //    }
        //}
    }
}
