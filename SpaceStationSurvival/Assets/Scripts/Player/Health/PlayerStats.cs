using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Canvas DeathCanvas;

    [Header("Max Bars")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float maxThirst = 100;
    [SerializeField] private float maxHunger = 120;
    [SerializeField] private float maxOxygen = 200;

    [Header("Bars")]
    public StatsBars healthBar;
    public StatsBars thirstBar;
    public StatsBars hungerBar;
    public StatsBars oxygenBar;

    [Header("Timer")]
    // Health
    public float timerHealth = 5.0f; //10.0f
    private float resetTimerHealth = 5.0f;
    // Thirst
    public float timerThirst = 7.0f; // 20.0f
    private float resetTimerThirst = 7.0f;
    // Hunger
    public float timerHunger = 5.0f; // 30.0f
    private float resetTimerHunger = 5.0f;
    // Oxygen
    public float timerOxygen = 9.0f; // 15.0f
    private float resetTimerOxygen = 9.0f;

    [Header("Current stats")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentThirst;
    [SerializeField] private float currentHunger;
    [SerializeField] private float currentOxygen;

    public bool ThirstZero = false;
    public bool HungerZero = false;
    public bool OxygenZero = false;


    // Start is called before the first frame update
    void Start()
    {
        DeathCanvas.enabled = false;

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
        Death();

        if (!ThirstZero)
        {
            timerThirst -= Time.deltaTime;
        }
        if(timerThirst < 0)
        {
            if (!ThirstZero)
            {
                LoseThirst(5);
                timerThirst = resetTimerThirst;

            }
            else
            {
                ThirstZero = true;
            }
        }

        if (!HungerZero)
        {
            timerHunger -= Time.deltaTime;
        }
        if (timerHunger < 0)
        {
            if (!HungerZero)
            {
                LoseHunger(5);
                timerHunger = resetTimerHunger;
            }
            else
            {
                HungerZero = true;
            }
        }

        if (!OxygenZero)
        {
            timerOxygen -= Time.deltaTime;
        }
        if (timerOxygen < 0)
        {
            if (!OxygenZero)
            {
                LoseOxygen(5);
                timerOxygen = resetTimerOxygen;
            }
            else
            {
                OxygenZero = true;
            }
        }

        if (currentHunger <= 0 || currentThirst <= 0)
        {
            timerHealth -= Time.deltaTime;
            if(timerHealth < 0)
            {
                TakeDamage(20);
                timerHealth = resetTimerHealth;
            }
        }

        StatsAreZero();
    }

    public void StatsAreZero()
    {
        if(currentOxygen <= 0)
        {
            OxygenZero = true;
        }

        if (currentThirst <= 0)
        {
            ThirstZero = true;
        }

        if (currentHunger <= 0)
        {
            HungerZero = true;
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
        ThirstZero = false;

        if (currentThirst > maxThirst)
        { //if current is over max
            currentThirst = maxThirst; //reset current to max 
        }
    }

    public void RestoreHunger(float amount)
    {
        currentHunger += amount;
        hungerBar.SetHungerSlider(currentHunger);
        HungerZero = false;

        if (currentHunger > maxHunger)
        { //if current is over max
            currentHunger = maxHunger; //reset current to max 
        }
    }

    public void RestoreOxygen(float amount)
    {
        currentOxygen += amount;
        oxygenBar.SetOxygenSlider(currentOxygen);
        OxygenZero = false;

        if (currentOxygen > maxOxygen)
        { //if current is over max
            currentOxygen = maxOxygen; //reset current to max 
        }
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

    public void Death()
    {
        if(currentHealth <= 0 || currentOxygen <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DeathCanvas.enabled = true;
        }
    }
}
