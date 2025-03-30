using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpcionesDeSonido : MonoBehaviour
{

    [SerializeField]
    AudioMixer mixerOpciones;
    [SerializeField]
    Slider efectos;
    [SerializeField]
    Slider master;
    [SerializeField]
    Slider musica;

    const string MixerOpciones_Master = "Master";
    const string MixerOpciones_Efectos = "SFX";
    const string MixerOpciones_Musica = "Musica";


    void Awake()
    {
        master.onValueChanged.AddListener(setMasterVolume);
        efectos.onValueChanged.AddListener(setEfectosVolume);
        musica.onValueChanged.AddListener(setMusicaVolume);


    }

    private void Start()
    {
    }
    void setMasterVolume(float value)
    {
        mixerOpciones.SetFloat(MixerOpciones_Master, Mathf.Log10(value) * 20);

    }
    void setEfectosVolume(float value)
    {
        mixerOpciones.SetFloat(MixerOpciones_Efectos, Mathf.Log10(value) * 20);

    }
    void setMusicaVolume(float value)
    {
        mixerOpciones.SetFloat(MixerOpciones_Musica, Mathf.Log10(value) * 20);

    }


}
