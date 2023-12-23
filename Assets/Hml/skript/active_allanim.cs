using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Desk_animation2 : MonoBehaviour
{

    [SerializeField] Animator animator;
      public string animation;
	public string currentAnimation;
	public bool luboe = false;
	void Animationn(string animation)
 	{
    	 if(currentAnimation == animation) return;



            
         


     	animator.Play(animation);
	
    	 currentAnimation = animation;
 }

    public void Animi()
    {
       
         
           
            
      Animationn(animation);
            luboe = true;
           
        
    }
}


