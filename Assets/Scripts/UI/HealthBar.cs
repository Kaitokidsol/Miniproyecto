using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    // Ajusta el valor máximo del slider de la barra de salud
    public void SetSliderMax(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
    }

    // Ajusta el valor actual del slider de la barra de salud
    public void SetSlider(float currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}

