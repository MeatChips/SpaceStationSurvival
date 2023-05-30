using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Max Bars")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxThirst;
    [SerializeField] private float maxHunger;
    [SerializeField] private float maxOxygen;

    [Header("Bars")]
    public StatsBars healthBar;
    public StatsBars thirstBar;
    public StatsBars hungerBar;
    public StatsBars oxygenBar;

    [Header("Timer")]
    public float resetTimeTHO = 30.0f;
    public float timerTHO = 30.0f;

    public float timerHealth = 10.0f;
    public float resetTimeH = 10.0f;

    // Current healths
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentThirst;
    [SerializeField] private float currentHunger;
    [SerializeField] private float currentOxygen;


    // Start is called before the first frame update
    void Start()
    {
        // Health
        currentHealth = maxHealth;

        healthBar.SetHealthSliderMax(maxHealth);

        // Thirst
        currentThirst = maxThirst;

        thirstBar.SetThirstSliderMax(maxThirst);

        // Hunger
        currentHunger = maxHunger;

        hungerBar.SetHungerSliderMax(maxHunger);

        // Oxygen
        currentOxygen = maxOxygen;

        oxygenBar.SetOxygenSliderMax(maxOxygen);
    }

    // Update is called once per frame
    void Update()
    {
        timerTHO -= Time.deltaTime;
        if (timerTHO < 0)
        {
            LoseThirst(5);
            LoseHunger(5);
            LoseOxygen(5);
            timerTHO = resetTimeTHO;
        }

        if (currentHunger == 0 || currentThirst == 0)
        {
            timerHealth -= Time.deltaTime;
            if(timerHealth < 0)
            {
                TakeDamage(20);
                timerHealth = resetTimeH;
            }
        }

    }


    #region Restore stats
    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        healthBar.SetHealthSlider(currentHealth);
    }

    public void RestoreThirst(float amount)
    {
        currentThirst += amount;
        thirstBar.SetThirstSlider(currentThirst);
    }

    public void RestoreHunger(float amount)
    {
        currentHunger += amount;
        hungerBar.SetHungerSlider(currentHunger);
    }

    public void RestoreOxygen(float amount)
    {
        currentOxygen += amount;
        oxygenBar.SetOxygenSlider(currentOxygen);
    }
    #endregion

    #region Lose stats
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealthSlider(currentHealth);
    }

    public void LoseThirst(float amount)
    {
        currentThirst -= amount;
        thirstBar.SetThirstSlider(currentThirst);
    }

    public void LoseHunger(float amount)
    {
        currentHunger -= amount;
        hungerBar.SetHungerSlider(currentHunger);
    }

    public void LoseOxygen(float amount)
    {
        currentOxygen -= amount;
        oxygenBar.SetOxygenSlider(currentOxygen);
    }
    #endregion
}
