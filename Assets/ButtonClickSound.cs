using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip buttonClickSound;  // El sonido que quieres para los botones
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método que se llama cuando se hace clic en el botón
    void buttonClickSoundOn()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
