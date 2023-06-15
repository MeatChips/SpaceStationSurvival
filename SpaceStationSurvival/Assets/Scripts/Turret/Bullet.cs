using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject Player;
    public PlayerStats playerStats;
    public float DeathTime = 5;

    private void Start()
    {
        //playerStats = Player.GetComponent<PlayerStats>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        Destroy(gameObject, DeathTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.TakeDamage(10);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
