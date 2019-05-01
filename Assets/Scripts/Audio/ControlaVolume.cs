using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaVolume : MonoBehaviour
{
    [SerializeField] private string volumeParameter;

    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey(volumeParameter))
        {
            volumeSlider.value = PlayerPrefs.GetFloat(volumeParameter);
        }
    }
}
