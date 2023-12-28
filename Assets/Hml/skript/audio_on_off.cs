using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_on_off : MonoBehaviour
{
    [SerializeField] GameObject sound;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject onPosition;
    [SerializeField] GameObject offPosition;

    public bool onOff = false;

    public void Start()
    {
        sound.SetActive(false);
        trigger.transform.position = onPosition.transform.position;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&onOff == false)
        {
            onOff = true;
            sound.SetActive(true);
            trigger.transform.position = offPosition.transform.position;
        }
        else if (other.CompareTag("Player") && onOff == true)
        {
            onOff = false;
            sound.SetActive(false);
            trigger.transform.position = onPosition.transform.position;
        }
    }
}
