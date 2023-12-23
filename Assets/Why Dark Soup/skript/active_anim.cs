using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation : MonoBehaviour
{

    [SerializeField] Animator animator;
      public string animation;
    public string animation2;
	public string currentAnimation;

    void Animationn(string animation)
 	{
    	 if(currentAnimation == animation) return;



            
         


     	animator.Play(animation);
	
    	 currentAnimation = animation;
 }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
           
            
              Animationn(animation);;
            }
           
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {


          currentAnimation = animation2;

        }
    }
}


