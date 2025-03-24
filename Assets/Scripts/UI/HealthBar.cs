using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    // Ajusta el valor máximo del slider de la barra de salud
    public void SetSliderMax(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth; 
        UpdateHealthText(maxHealth, maxHealth);
    }

    // Ajusta el valor actual del slider de la barra de salud
    public void SetSlider(float currentHealth)
    {
        healthSlider.value = currentHealth;
        UpdateHealthText(currentHealth, healthSlider.maxValue);
    }

    private void UpdateHealthText(float currentHealth, float maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
        }
    }
}

