using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;

    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffect;

    private AudioSource shotAudioSrc;

    void Start()
    {
        shotAudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!shotAudioSrc.isPlaying)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        MuzzleFlash.Play();
        shotAudioSrc.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);

            TargetObject target = hit.transform.GetComponent<TargetObject>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }

            GameObject ImpactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2f);
        }
    }
}
