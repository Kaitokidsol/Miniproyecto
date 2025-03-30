using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] public AudioMixer audioMixer;

    const string MixerOpciones_Master = "Master";
    const string MixerOpciones_Efectos = "SFX";
    const string MixerOpciones_Musica = "Musica";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {  Destroy(gameObject); }
        LoadVolume();
    }
    void LoadVolume() 
    {
        float masterVolume = PlayerPrefs.GetFloat(MixerOpciones_Master, 1f);

        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume)* 20);
        
        float SFXVolume = PlayerPrefs.GetFloat(MixerOpciones_Efectos, 1f);

        audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
        
        float MusicaVolume = PlayerPrefs.GetFloat(MixerOpciones_Musica, 1f);

        audioMixer.SetFloat("Musica", Mathf.Log10(MusicaVolume) * 20);
    }
}
