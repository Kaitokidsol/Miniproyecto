using UnityEngine;

public class TrapDamange : MonoBehaviour
{
    public float damageAmount = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Da�o aplicado");
            other.GetComponent<PlayerStats>().TakeDamage(damageAmount);
        }
    }
}
