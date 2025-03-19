using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextLevel; // Asigna el nombre de la escena siguiente en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Cambiando a " + nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
