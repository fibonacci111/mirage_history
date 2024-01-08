using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum SoundEnum
{
    Music, 
    Effect
}
public class SoundController : MonoBehaviour
{
    [SerializeField] SoundEnum SoundType;
    [SerializeField] AudioSource audioSource;
    float SoundVolume;
    

    private void Start()
    {
        SoundVolume = audioSource.volume;

        switch (SoundType)
        {
            case SoundEnum.Music:
                
                SoundAdministrator.instance.MusicSlider.onValueChanged.AddListener(SetSound);
                
                audioSource.volume = SoundAdministrator.instance.MusicSlider.value;
                break;

            case SoundEnum.Effect:
                
                SoundAdministrator.instance.EffectsSlider.onValueChanged.AddListener(SetSound);
              
                audioSource.volume = SoundAdministrator.instance.EffectsSlider.value;
                break; 
        }        
    }
   

    public void SetSound(float volume)
    {
        audioSource.volume = volume * SoundVolume;
    }


}
