using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100; // Salud máxima
    public float currentHealth;

    public HealthBar healthBar; // Referencia a la barra de salud

    // Al comenzar, inicializamos la salud
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth); // Ajusta la barra de salud al máximo
    }

    // Método para aplicar daño
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Evita que la salud sea negativa
        }
        healthBar.SetSlider(currentHealth); // Actualiza la barra de salud
    }

    // Método para curar
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Evita que la salud suba por encima del máximo
        }
        healthBar.SetSlider(currentHealth); // Actualiza la barra de salud
    }


    private void Update()
    {
        // Se asegura de que la salud nunca sea mayor que la salud máxima
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
