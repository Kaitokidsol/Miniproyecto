using UnityEngine;

public class Diana : MonoBehaviour
{
    public int maxHits = 5; // Número de disparos antes de destruirse
    private int currentHits = 0;
    public bool isDead = false;

    public void TakeDamage()
    {
        if (isDead) return;

        currentHits++;

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject); // Destruye el enemigo
    }
}
