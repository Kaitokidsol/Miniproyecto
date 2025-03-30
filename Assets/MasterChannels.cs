using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MasterChannels : MonoBehaviour
{
    [SerializeField]
    private AudioMixer master;

    [SerializeField]
    Soundsvarios[] sounds;

    public void PlaySFX(string name)
    {
        foreach (Soundsvarios s in sounds)
        {
            if (s.name == name)
            {
                GetComponent<AudioSource>().clip = s.clip;
                GetComponent<AudioSource>().volume = s.volume;
                GetComponent<AudioSource>().loop = s.loop;

                if (s.randomPitch)
                {
                    GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.7f, 1.8f);
                }
                else
                {
                    GetComponent<AudioSource>().pitch = s.pitch;
                }


                break;
            }

        }
        Soundsvarios sfx = Array.Find(sounds, sound => sound.name == name);
        GetComponent<AudioSource>().Play();

    }


}
