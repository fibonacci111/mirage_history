using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float SpeedOverclocking;

    float SpeedActive;
    float JumpActive;
    float UmbrellaActive;
    float LandActive;
    
    bool isGrounded;

    public void Update()
    {
        anim.SetFloat("Idle_Walking_Run", SpeedActive);
        anim.SetFloat("Idle_Jump_InAir_Landing", JumpActive);
        SetAnimLanding();
    }

    public void SetAnimIdle()
    {
        SpeedActive = Mathf.MoveTowards(SpeedActive, 0f, SpeedOverclocking);
    }

    public void SetAnimWalk()
    {      
        SpeedActive = Mathf.MoveTowards(SpeedActive, 1f, SpeedOverclocking);
    }

    public void SetAnimRun()
    {  
        SpeedActive = Mathf.MoveTowards(SpeedActive, 2f, SpeedOverclocking);
    }

    public void SetAnimJump()
    { 
        JumpActive = Mathf.MoveTowards(JumpActive, 2f, SpeedOverclocking);
    }

    public void SetAnimLanding()
    {
        if (CharacterMovement.Instance.isGround != isGrounded)
        {
            isGrounded = !isGrounded;
            if (isGrounded)
            {
                anim.SetBool("IsJumping", false);

                if (anim.GetBool("IsUmbrella") == false)
                    anim.CrossFade("Landing", 0.2f);
                
                SetAnimUmbrellaClose();
                JumpActive = 3;
            }
            else
            {
                JumpActive = 2;
                anim.SetBool("IsJumping", true);
            }
        }
    }

    public void SetAnimUmbrellaOpen()
    {
        anim.SetBool("IsUmbrella", true);
        anim.SetFloat("InAir_UmbrellaOn_Soaring_UmbrellaLanding", 2);
    }

    public void SetAnimUmbrellaClose()
    {
        if (anim.GetBool("IsUmbrella") == true)
        {
            anim.SetBool("IsUmbrella", false);
            anim.CrossFade("Umbrella_Landing", 0.2f);
        }
    }

}
