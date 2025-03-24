using UnityEngine;
using System.Collections;

public class TrapDamange : MonoBehaviour
{
    public float damageAmount = 5f;
    public float damageInterval = 0.5f; // Tiempo entre cada da�o
    private bool playerInTrap = false; // Para saber si el jugador sigue en la trampa

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInTrap)
        {
            playerInTrap = true;
            StartCoroutine(DamageOverTime(other.GetComponent<PlayerStats>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrap = false;
        }
    }

    private IEnumerator DamageOverTime(PlayerStats playerStats)
    {
        while (playerInTrap && playerStats.currentHealth > 0)
        {
            Debug.Log("Da�o aplicado por los pinchos");
            playerStats.TakeDamage(damageAmount);
            yield return new WaitForSeconds(damageInterval); // Espera antes de aplicar da�o de nuevo
        }
    }
}
