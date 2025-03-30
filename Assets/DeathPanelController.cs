using UnityEngine;

public class DeathPanelController : MonoBehaviour
{
    public GameObject deathPanel;  // El panel de muerte (arrástralo desde el inspector)

    void Start()
    {
        // Asegúrate de que el cursor esté oculto al comenzar
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor
    }

    public void ShowDeathPanel()
    {
        // Muestra el panel de muerte
        deathPanel.SetActive(true);

        // Haz visible el cursor y desbloquéalo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor
    }

    public void HideDeathPanel()
    {
        // Oculta el panel de muerte
        deathPanel.SetActive(false);

        // Asegúrate de que el cursor esté oculto y bloqueado cuando regrese al juego
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor de nuevo
    }
}

