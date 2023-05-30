using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBars : MonoBehaviour
{
    public Slider healthSlider;
    public Slider thirstSlider;
    public Slider hungerSlider;
    public Slider oxygenSlider;

    #region Health
    public void SetHealthSlider(float amount)
    {
        healthSlider.value = amount;
    }

    public void SetHealthSliderMax(float amount)
    {
        healthSlider.maxValue = amount;
        SetHealthSlider(amount);
    }
    #endregion

    #region Thirst
    public void SetThirstSlider(float amount)
    {
        thirstSlider.value = amount;
    }

    public void SetThirstSliderMax(float amount)
    {
        thirstSlider.maxValue = amount;
        SetThirstSlider(amount);
    }
    #endregion

    #region Hunger
    public void SetHungerSlider(float amount)
    {
        hungerSlider.value = amount;
    }

    public void SetHungerSliderMax(float amount)
    {
        hungerSlider.maxValue = amount;
        SetHungerSlider(amount);
    }
    #endregion

    #region Oxygen
    public void SetOxygenSlider(float amount)
    {
        oxygenSlider.value = amount;
    }

    public void SetOxygenSliderMax(float amount)
    {
        oxygenSlider.maxValue = amount;
        SetOxygenSlider(amount);
    }
    #endregion
}
