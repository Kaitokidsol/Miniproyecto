using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Camera.main.gameObject.AddComponent<CinemachineBrain>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
