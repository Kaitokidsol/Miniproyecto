using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;
    public float tiempoAntesDeDestruir = 2f; // Tiempo antes de destruir el enemigo



    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
            else Debug.Log("Hit");
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
