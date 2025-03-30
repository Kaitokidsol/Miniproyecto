using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        if (EnemyCounter.Instance != null)
        {
            EnemyCounter.Instance.AddEnemy();
        }
        else
        {
            Debug.LogError("EnemyCounter no encontrado en la escena.");
        }
    }

    private void OnDestroy()
    {
        if (EnemyCounter.Instance != null)
        {
            EnemyCounter.Instance.RemoveEnemy();
        }
    }
}
