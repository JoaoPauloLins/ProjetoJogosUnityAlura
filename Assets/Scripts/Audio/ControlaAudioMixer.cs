using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlaAudioMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string volumeParameter;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey(volumeParameter))
        {
            MudarVolume(PlayerPrefs.GetFloat(volumeParameter));
        }
    }

    public void MudarVolume(float volume)
    {
        audioMixer.SetFloat(volumeParameter, volume);
        PlayerPrefs.SetFloat(volumeParameter, volume);
    }
}
