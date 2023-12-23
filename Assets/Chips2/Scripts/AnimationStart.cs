using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    [SerializeField] Animation anim;
    bool enter;
    [SerializeField] bool БесконечноеПроигрываниеАнимации = true;
    void Update()
    {
        if(enter&& БесконечноеПроигрываниеАнимации)
        {
            anim.Play();
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
