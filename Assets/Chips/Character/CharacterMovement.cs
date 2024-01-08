using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] CharacterController characterController;
    [SerializeField] CharacterAnimations characterAnimations;
    [Space]
    [Space]
    [SerializeField, Min(1)] float WalkSpeed = 5;
    [SerializeField, Min(1)] float SprintSpeed = 10;
    [SerializeField, Min(1)] float RotateSpeed;
    [SerializeField, Min(1)] float JumpHeight;
    [SerializeField, Min(1)] float JumpSpeed;
    [Space]
    [Space]
    [SerializeField, Range(-100, -1)] float StandardGravity = -9.8f;
    [SerializeField] float WindGravity;
    [SerializeField] float UmbrellaGravity;
    [Space]
    [Space]
    [SerializeField] LayerMask wind;
    [SerializeField] float WindDistanse;
    [SerializeField] Color WindDistanseColor;
    [Space]
    [Space]
    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundDistanse = 0.4f;
    [SerializeField] LayerMask Ground;
    
    bool IsGround = true;
    bool isJumping = false;
    bool isOpen = false;
    bool isGrounded;

    float CurrentSpeed;
    
    internal bool UmbrellaIsOpen;
    internal Vector3 velosity;
    
    GravityStateMachine state = new GravityStateMachine();
    
    public static CharacterMovement Instance;
    public float gravity => StandardGravity;
    public bool isGround => IsGround;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CurrentSpeed = WalkSpeed;
        state.SetState(new NormalState(StandardGravity));
      
    }

    private void Update()
    {
        IsGround = Physics.CheckSphere(GroundCheck.position, GroundDistanse, Ground, QueryTriggerInteraction.Ignore);

        if (isGround != isGrounded)
        {
        isGrounded = !isGrounded;
            
            if (isGrounded)
                CurrentSpeed = WalkSpeed;
        }
      

        if (IsGround)
        {
            state.SetState(new NormalState(StandardGravity));
        }
            Gravity();
 
    }

    public void OpenMenu(bool isKeyDown)
    {
       

        if (isKeyDown)
        {
            if (!isOpen)
            {
                menu.SetActive(true);
                isOpen = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else if (isOpen)
            {
                menu.SetActive(false);
                isOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
  
    public void MoveCharacter(Vector3 movement, bool isRun)
    {
        characterController.Move(movement * CurrentSpeed * Time.deltaTime);

        if (isRun&&!Input.GetKey(KeyCode.LeftShift))
            characterAnimations.SetAnimWalk();
        if (!isRun && isGround)
            characterAnimations.SetAnimIdle();
    }

    public void RotateCharacter(Vector3 movement)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
        float rotationSpeed = RotateSpeed * Time.deltaTime;

        if (movement != Vector3.zero)
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed);
    }

    public void SetSprint(bool setSprint)
    {
        if (!IsGround)
            return;

        if (setSprint)
        {
            CurrentSpeed = SprintSpeed;
            characterAnimations.SetAnimRun();
        }
        else
            CurrentSpeed = WalkSpeed;
    }

    public void Gravity()
    {
        if (IsGround && velosity.y < 0)
            velosity.y = -2f;

        
        velosity.y += state.CurrentState.gravity * Time.deltaTime;
        characterController.Move(velosity * Time.deltaTime);

    }

    public void Jump()
    {
        isJumping = !isJumping;

        if (!isJumping && !IsGround)
            return;

        if (IsGround)
        {
            CurrentSpeed = JumpSpeed;
            characterAnimations.SetAnimJump();
            velosity.y = Mathf.Sqrt(-JumpHeight * StandardGravity);
        }  

    }

    public void SetUmbrellaState()
    {
        if (!IsGround&&!UmbrellaIsOpen)
        {
            characterAnimations.SetAnimUmbrellaOpen();
            state.SetState(new UmbrellaState(UmbrellaGravity, WindGravity, WindDistanse, this, wind));
            
            UmbrellaIsOpen = true;
            velosity.y = 0;

        }
        else if (UmbrellaIsOpen)
        {
            characterAnimations.SetAnimUmbrellaClose();
            state.SetState(new NormalState(StandardGravity));
           
            UmbrellaIsOpen = false;
            velosity.y = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = WindDistanseColor;
        Gizmos.DrawSphere(transform.position, WindDistanse);
        Gizmos.DrawSphere(GroundCheck.position, GroundDistanse);
    }

}
