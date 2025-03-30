using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cambiar de escenas

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Referencia al Panel de pausa
    public bool isPaused = false;   // Marcador para saber si el juego est� pausado

    public MonoBehaviour[] movementScripts;  // Array para los scripts de movimiento
    public MonoBehaviour[] shootingScripts;  // Array para los scripts de disparo

    void Update()
    {
        // Detecta cuando se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();  // Si el juego est� en pausa, reanudarlo
            else
                PauseGame();  // Si el juego no est� en pausa, pausarlo
        }
    }

    // M�todo para pausar el juego
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // Muestra el men� de pausa
        Time.timeScale = 0f;  // Detiene el tiempo del juego (pausa)
        isPaused = true;  // Marca que el juego est� en pausa

        // Desactiva todos los scripts de movimiento y disparo
        ToggleScripts(movementScripts, false);  // Desactiva el movimiento
        ToggleScripts(shootingScripts, false);  // Desactiva el disparo

        // Detener las animaciones si las hay
        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            animator.speed = 0f;  // Detiene todas las animaciones
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    // M�todo para reanudar el juego
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);  // Oculta el men� de pausa
        Time.timeScale = 1f;  // Reanuda el tiempo del juego
        isPaused = false;  // Marca que el juego no est� en pausa

        // Reactiva todos los scripts de movimiento y disparo
        ToggleScripts(movementScripts, true);  // Reactiva el movimiento
        ToggleScripts(shootingScripts, true);  // Reactiva el disparo

        // Restaurar las animaciones
        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            animator.speed = 1f;  // Restaura la velocidad de las animaciones
        }

        // Restaurar el control del cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor de nuevo
        Cursor.visible = false; // Ocultar el cursor
    }

    // M�todo para cambiar entre habilitar o deshabilitar scripts
    private void ToggleScripts(MonoBehaviour[] scripts, bool enable)
    {
        foreach (var script in scripts)
        {
            script.enabled = enable;  // Habilita o deshabilita el script
        }
    }

    // M�todo para ir al men� principal
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // Asegurarse de que el tiempo se reanude antes de cargar otra escena
        SceneManager.LoadScene("MainMenu");  // Cambia "MainMenu" por el nombre de tu escena de men� principal
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();  // Sale de la aplicaci�n
    }
}
