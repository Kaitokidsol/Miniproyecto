using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;
    public float tiempoAntesDeDestruir = 2f;

    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }

    }

    void EnemyDeath()
    {
        if (!isDead)
        {
            isDead = true;
            ragdollManager.TriggerRagdoll();
            Debug.Log("Death");

            // Destruir el enemigo después de un tiempo
            Destroy(gameObject, tiempoAntesDeDestruir);
        }
    }
}
