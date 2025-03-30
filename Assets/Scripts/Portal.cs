using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string[] niveles; // Lista de nombres de niveles (asignar en Inspector)

    private void Start()
    {
        if (niveles == null || niveles.Length == 0)
        {
            Debug.LogError("¡Error! La lista niveles[] está vacía en el Portal.");
        }
        else
        {
            Debug.Log("Lista de niveles cargada:");
            foreach (string nivel in niveles)
            {
                Debug.Log(nivel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string nivelActual = SceneManager.GetActiveScene().name;
            Debug.Log("Nivel actual: " + nivelActual);

            int indiceActual = System.Array.IndexOf(niveles, nivelActual);
            Debug.Log("Índice encontrado: " + indiceActual);

            if (indiceActual >= 0 && indiceActual < niveles.Length - 1)
            {
                Debug.Log("Cargando siguiente nivel: " + niveles[indiceActual + 1]);
                SceneManager.LoadScene(niveles[indiceActual + 1]);
            }
            else
            {
                Debug.LogWarning("No se encontró el nivel actual en la lista, cargando MenuVictoria.");
                // Asegurarse de que el cursor sea visible y libre
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("MenuVictoria");
            }
        }
    }
}
