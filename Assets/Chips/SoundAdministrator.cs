using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundAdministrator : MonoBehaviour
{
    
    public Slider MusicSlider;
    public Slider EffectsSlider;
   

    public static SoundAdministrator instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        

       
        MusicSlider.value = PlayerPrefs.GetFloat("MusicValue");
        EffectsSlider.value = PlayerPrefs.GetFloat("EffectsValue");
        
        MusicSlider.onValueChanged.AddListener(SaveMusicChanges);
        EffectsSlider.onValueChanged.AddListener(SaveEffectsChanges);
       
    }

    public void SaveMusicChanges(float value)
    {
        PlayerPrefs.SetFloat("MusicValue", value);
        PlayerPrefs.Save();
    }

    public void SaveEffectsChanges(float value)
    {
        PlayerPrefs.SetFloat("EffectsValue", value);
        PlayerPrefs.Save();
    }

}
