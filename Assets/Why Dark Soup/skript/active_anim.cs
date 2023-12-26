using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation : MonoBehaviour
{

    [SerializeField] Animator animator;
      public string animation;
    public string animation2;
	public string currentAnimation;
    public bool spirit;

    void Animationn(string animation)
 	{
    	 if(currentAnimation == animation) return;



            
         


     	animator.Play(animation);
	
    	 currentAnimation = animation;
 }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&&spirit == false)
        { 
           
            
              Animationn(animation);;
        }
        if (other.CompareTag("spirit") && spirit == true)
        {


            Animationn(animation); ;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && spirit == false)
        {


          currentAnimation = animation2;

        }
        if (other.CompareTag("spirit") && spirit == true)
        {


            currentAnimation = animation2;

        }
    }
}


