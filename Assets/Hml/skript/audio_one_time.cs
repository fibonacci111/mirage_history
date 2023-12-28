using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_one_time : MonoBehaviour
{
    [SerializeField] GameObject sound;
    [SerializeField] GameObject spawn;
    private bool on = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&on == false)
        {
            Instantiate(sound, spawn.transform);
            on = true;
        } 
    }
}
