using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar y recargar escenas

public class RestartGame : MonoBehaviour
{
    // Función para reiniciar la escena actual
    public void RestartScene()
    {
        // Obtiene el nombre de la escena actual y la recarga
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);  // Recarga la escena actual
    }
}
