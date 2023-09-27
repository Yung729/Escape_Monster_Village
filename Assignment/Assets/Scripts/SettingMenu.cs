using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer masterAudio;
    private float value;

    private void Start() {
        masterAudio.GetFloat("Volume",out value);
        volumeSlider.value = value;
    }

    public void SetVolume(float volume) {
        masterAudio.SetFloat("Volume", volumeSlider.value);
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
