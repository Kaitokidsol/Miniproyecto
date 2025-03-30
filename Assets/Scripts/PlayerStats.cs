using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100; // Salud m�xima
    public float currentHealth;

    public HealthBar healthBar; // Referencia a la barra de salud

    public DeathPanelController deathPanelController;
    public GameObject player;

    private bool isDead = false;

    // Al comenzar, inicializamos la salud
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth); // Ajusta la barra de salud al m�ximo
    }

    // M�todo para aplicar da�o
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0; // Evita que la salud sea negativa
            deathPanelController.ShowDeathPanel();
            Die();
        }
        healthBar.SetSlider(currentHealth); // Actualiza la barra de salud
    }

    void Die()
    {
        isDead = true;

        // Desactivar al jugador (el objeto del jugador)
        player.SetActive(false);
    }

    // M�todo para curar
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Evita que la salud suba por encima del m�ximo
        }
        healthBar.SetSlider(currentHealth); // Actualiza la barra de salud
    }



    private void Update()
    {
        // Se asegura de que la salud nunca sea mayor que la salud m�xima
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
