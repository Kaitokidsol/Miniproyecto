using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAmount;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            // Solo cura si la vida no est� al m�ximo
            if (playerStats.currentHealth < playerStats.maxHealth)
            {
                playerStats.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }

   
}
