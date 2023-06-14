using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public float Health;

    public ParticleSystem destroyPS;

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(destroyPS, transform.position, transform.rotation);
        Destroy(gameObject);
        //destroyPS.Play();
        //Destroy(gameObject);

    }
}
