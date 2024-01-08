using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript_ : MonoBehaviour
{
    [SerializeField] AudioClip[] steps;
    [SerializeField] AudioSource stepSource;

    public void FootStepsPlay()
    {
        //stepSource.clip = steps[Random.Range(0, steps.Length)];
        stepSource.PlayOneShot(steps[Random.Range(0, steps.Length)]);
        Debug.Log("run");
    }
}

