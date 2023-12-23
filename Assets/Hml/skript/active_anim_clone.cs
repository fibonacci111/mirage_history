using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation3 : MonoBehaviour
{

    [SerializeField] Animator animator;
      public string animation;
	public string currentAnimation;
	public string animation2;
	private void Update()
{
	if(Desk_animation2.luboe==true)
{
	currentAnimation = animation2;
}
}
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


