using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation : MonoBehaviour
{

    [SerializeField] Animator animator;
      public string animation;
	public string currentAnimation;
	void Animationn(string animation)
 	{
    	 if(currentAnimation == animation) return;



            
         


     	animator.Play(animation);
	
    	 currentAnimation = animation;
 }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
           
            
              Animationn(animation);
            }
           
        
    }
}


