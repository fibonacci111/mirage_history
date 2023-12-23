using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation1 : MonoBehaviour
{

    [SerializeField] Animator animator;
    public string animation;
    public string currentAnimation;
    public bool key = false;
    public bool key1 = false;
    private void Update()

    {
        if (key1 == true&& Input.GetKeyDown(KeyCode.F))
        {
            key = true;

        }


    }
    void Animationn1(string animation)
    {
        if (currentAnimation == animation) return;


        animator.Play(animation);

        currentAnimation = animation;
        key = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        key1 = true;
        if (other.CompareTag("Player") && key == true)
        {


            Animationn1(animation);
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        key1 = false;
    }



}