using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetEffectVolume : MonoBehaviour
{
    public AudioMixer effectMixer;
    public Slider effectSlider;

    void Start()
    {
        effectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 0.75f);
    }
    public void SetEffectLevel()
    {
        float sliderValue = effectSlider.value;
        effectMixer.SetFloat("EffectVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectVolume", sliderValue);
    }
}