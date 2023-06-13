using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSeek : MonoBehaviour
{
    [Header("Seeking Stuff")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform rotationPart;
    [SerializeField] private Transform turretHead;
    [SerializeField] private Camera turretCam;


    void Start()
    {
        
    }

    void Update()
    {
        SeekForPlayer();
    }

    public void SeekForPlayer()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        float rayLength = 10f;
        Ray ray = turretCam.ViewportPointToRay(rayOrigin);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Player"))
            {
                print("Did Hit");
            }
        }
    }

    public void TurretShoot()
    {

    }
}
