using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance;
    private int enemyCount = 0;
    public GameObject portal; // Asigna el portal en el Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (portal != null)
        {
            portal.SetActive(false); // Ocultar el portal al inicio
        }
        else
        {
            Debug.LogWarning("Portal no asignado en EnemyCounter.");
        }
    }

    public void AddEnemy()
    {
        enemyCount++;
        Debug.Log("Enemigo agregado. Total: " + enemyCount);
    }

    public void RemoveEnemy()
    {
        enemyCount--;
        Debug.Log("Enemigo eliminado. Restantes: " + enemyCount);

        if (enemyCount <= 0)
        {
            Debug.Log("Todos los enemigos eliminados. Activando portal.");
            if (portal != null)
            {
                portal.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Portal no asignado.");
            }
        }
    }
}

