using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public HealthBar healthBar;

    public float resetTime = 30.0f;
    public float timeLeft = 30.0f;

    private float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            TakeDamage(20);
            timeLeft = resetTime;
        }

        Debug.Log(timeLeft);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
    }
}
