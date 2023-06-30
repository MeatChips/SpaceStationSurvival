using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBalls : MonoBehaviour
{
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Ball4;
    public GameObject BigBall1;

    public float rotatingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ball1.transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);
        Ball2.transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);
        Ball3.transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);
        Ball4.transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);
        BigBall1.transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime); 
    }
}
