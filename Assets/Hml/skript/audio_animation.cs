using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_animation : MonoBehaviour
{
    [SerializeField] GameObject sound;
    [SerializeField] GameObject spawn;
    public void PlaySound()
    {
        Instantiate(sound, spawn.transform);
    }
}
