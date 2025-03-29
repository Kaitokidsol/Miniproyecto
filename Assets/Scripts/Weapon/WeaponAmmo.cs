using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using UnityEngine.Audio;
using TMPro;

public class WeaponAmmo : MonoBehaviour
{
    public int clipSize;
    public int extraAmmo;
    [HideInInspector] public int currentAmmo;

    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;


    [SerializeField] private TMP_Text ammoUIText; // Referencia al texto de la UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = clipSize;

        // Buscar el objeto AmmoDisplay en el Canvas si no está asignado
        if (ammoUIText == null)
        {
            GameObject textObject = GameObject.Find("AmmoDisplay");
            if (textObject != null)
                ammoUIText = textObject.GetComponent<TMP_Text>();
        }

        UpdateAmmoText(); // Mostrar la munición al iniciar
    }

    

    public void Reload()
    {
        if (extraAmmo > 0 && currentAmmo < clipSize)
        {
            int ammoNeeded = clipSize - currentAmmo;
            int ammoToReload = Mathf.Min(extraAmmo, ammoNeeded);

            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;

            UpdateAmmoText(); // ✅ Ahora actualiza la UI al recargar
        }
    }

    public void UpdateAmmoText()
    {
        if (ammoUIText != null)
            ammoUIText.text = $"{currentAmmo}/{extraAmmo}";
    }

    public void SetAmmoUIText(TMP_Text text)
    {
        ammoUIText = text;
        UpdateAmmoText(); // Para actualizar la UI al cambiar de arma
    }
}
