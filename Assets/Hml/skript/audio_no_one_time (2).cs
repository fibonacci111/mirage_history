using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_no_one_time : MonoBehaviour
{
    [SerializeField] GameObject sound;
    [SerializeField] GameObject spawn;
    public int delay;
    private bool delayb = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && delayb == false)
        {
            delayb = true;
            StartCoroutine(t1());
        }
    }

    IEnumerator t1()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(sound, spawn.transform);
        delayb = false;
    }
}
