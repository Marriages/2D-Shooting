using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOption : MonoBehaviour
{
    Slider musicSlider;
    Slider effectSlider;

    private void Awake()
    {
        musicSlider = transform.GetChild(0).GetChild(1).GetComponent<Slider>();
        effectSlider = transform.GetChild(1).GetChild(1).GetComponent<Slider>();

    }

    private void OnEnable()
    {
        musicSlider.onValueChanged.AddListener(BackgroundSoundSliderUpdate);
        effectSlider.onValueChanged.AddListener(EffectSoundSliderUpdate);
    }
    private void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(BackgroundSoundSliderUpdate);
        effectSlider.onValueChanged.RemoveListener(EffectSoundSliderUpdate);
    }
    private void Start()
    {
        musicSlider.value = AudioManager.instance.BackSoundSize;
        effectSlider.value = AudioManager.instance.EffectSoundSize;
    }
    void BackgroundSoundSliderUpdate(float value)
    {
        AudioManager.instance.BackSoundSize = value;
    }
    void EffectSoundSliderUpdate(float value)
    {
        AudioManager.instance.EffectSoundSize = value;
    }



}
