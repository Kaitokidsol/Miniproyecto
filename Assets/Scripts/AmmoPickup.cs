using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 30; // Cantidad de munici�n del pickup

    private void OnTriggerEnter(Collider other)
    {
        WeaponAmmo playerAmmo = other.GetComponentInChildren<WeaponAmmo>();

        if (playerAmmo != null)
        {
            int maxExtraAmmo = 150; // L�mite m�ximo de munici�n extra

            // Verificar si a�n puede recoger munici�n
            if (playerAmmo.extraAmmo < maxExtraAmmo)
            {
                int ammoToAdd = Mathf.Min(ammoAmount, maxExtraAmmo - playerAmmo.extraAmmo);
                playerAmmo.extraAmmo += ammoToAdd;
                playerAmmo.UpdateAmmoText(); // Refrescar UI

                Destroy(gameObject); // Eliminar el pickup despu�s de recogerlo
            }
        }
    }
}
