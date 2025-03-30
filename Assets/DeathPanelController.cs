using UnityEngine;

public class DeathPanelController : MonoBehaviour
{
    public GameObject deathPanel;  // El panel de muerte (arr�stralo desde el inspector)

    void Start()
    {
        // Aseg�rate de que el cursor est� oculto al comenzar
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor
    }

    public void ShowDeathPanel()
    {
        // Muestra el panel de muerte
        deathPanel.SetActive(true);

        // Haz visible el cursor y desbloqu�alo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor
    }

    public void HideDeathPanel()
    {
        // Oculta el panel de muerte
        deathPanel.SetActive(false);

        // Aseg�rate de que el cursor est� oculto y bloqueado cuando regrese al juego
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor de nuevo
    }
}

