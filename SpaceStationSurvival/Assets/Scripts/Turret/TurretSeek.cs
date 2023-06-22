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

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletCasePrefab;
    [SerializeField] private Transform bulletSpawnPointOne;

    [Header("Turret Stats")]
    [SerializeField] private float Speed;
    [SerializeField] private float timerTotal = 2f;
    private float timerCurrent = 0f;
    private float timerMin = 0f;

    private AudioSource shotAudioSrc;

    void Start()
    {
        shotAudioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        timerCurrent += Time.deltaTime;
        if(GameObject.FindWithTag("Turret Top"))
        {
            SeekForPlayer();
        }
        else
        {
            return;
        }
    }

    public void SeekForPlayer()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        float rayLength = 40f;
        Ray ray = turretCam.ViewportPointToRay(rayOrigin);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if(timerCurrent >= timerTotal)
                {
                    shotAudioSrc.Play();
                    TurretShoot();
                    timerCurrent = timerMin;
                }
            }
        }
    }

    public void TurretShoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPointOne.position, bulletSpawnPointOne.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPointOne.forward * Speed;
    }
}
