using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "1"; // Cambia esto por el nombre de tu escena principal

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OpenOptions()
    {
        // Aquí puedes activar un panel de opciones si lo tienes
        Debug.Log("Abrir Opciones (Implementar en UI)");
    }

    public void QuitGame()
    {
        Debug.Log("Salir del Juego");
        Application.Quit();
    }
}

