using UnityEngine;

public class TrapDamange : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Da�o");
            other.GetComponent<PlayerStats>().TakeDamage(damageAmount);
        }
    }
}
