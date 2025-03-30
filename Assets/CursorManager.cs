using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // Asegurarse de que el cursor sea visible y libre de moverse
        Cursor.visible = true;  // Hace que el cursor sea visible
        Cursor.lockState = CursorLockMode.None;  // Permite que el cursor se mueva libremente
    }
}

