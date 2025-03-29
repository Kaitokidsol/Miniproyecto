using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 30; // Cantidad de munición del pickup

    private void OnTriggerEnter(Collider other)
    {
        WeaponAmmo playerAmmo = other.GetComponentInChildren<WeaponAmmo>();

        if (playerAmmo != null)
        {
            int maxExtraAmmo = 150; // Límite máximo de munición extra

            // Verificar si aún puede recoger munición
            if (playerAmmo.extraAmmo < maxExtraAmmo)
            {
                int ammoToAdd = Mathf.Min(ammoAmount, maxExtraAmmo - playerAmmo.extraAmmo);
                playerAmmo.extraAmmo += ammoToAdd;
                playerAmmo.UpdateAmmoText(); // Refrescar UI

                Destroy(gameObject); // Eliminar el pickup después de recogerlo
            }
        }
    }
}
