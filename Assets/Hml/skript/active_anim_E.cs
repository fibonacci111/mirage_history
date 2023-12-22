using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation1 : MonoBehaviour
{
  
    [SerializeField] Animator animator;
      public string animation;
  public string currentAnimation;
  public bool key=false;
  private void FixitUpdate()
  
{
  if(Input.GetKeyDown(KeyCode.F))
{
  key=true;
  
}
  

}
  void Animationn1(string animation)
   {
       if(currentAnimation == animation) return;


       animator.Play(animation);
  
       currentAnimation = animation;
	key=false;
 }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.F))
        { 
                

              Animationn1(animation);
}
 else{key=false;}  		 
            }
           
        
    
	
}
