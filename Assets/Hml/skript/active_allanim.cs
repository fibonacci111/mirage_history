using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Desk_animation2 : MonoBehaviour
{

    [SerializeField] Animator animator;
      public string animation;
	public string currentAnimation;


    public void Animi()
    {



        animator.Play(animation);


    }
}


