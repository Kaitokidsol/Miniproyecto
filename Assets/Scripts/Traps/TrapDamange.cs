using UnityEngine;

public class TrapDamange : MonoBehaviour
{
    public float damageAmount = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Daño aplicado");
            other.GetComponent<PlayerStats>().TakeDamage(damageAmount);
        }
    }
}
