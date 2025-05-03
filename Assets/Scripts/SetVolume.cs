using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void SetLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}