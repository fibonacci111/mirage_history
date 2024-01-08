using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] SecondCharacterMovement secondCharacterMovement;
    Vector3 movement;
    float up = 0;

    bool isFirstPlayer = true;

 
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Tab))
        {          
            if (isFirstPlayer)
                isFirstPlayer = false;
            else if ( !isFirstPlayer)
                isFirstPlayer = true;
        }


        if (isFirstPlayer)
        {
            if (movement != Vector3.zero)
                characterMovement.RotateCharacter(movement);

            characterMovement.MoveCharacter(movement, movement != Vector3.zero);
            characterMovement.SetSprint(Input.GetKey(KeyCode.LeftShift) && movement != Vector3.zero);
       

            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterMovement.Jump();
                characterMovement.SetUmbrellaState();
            }
        }

            if (Input.GetKey(KeyCode.LeftShift))
                up = 1;
            else if (Input.GetKey(KeyCode.LeftAlt))
                up = -1;
            else
                up = 0;
            
            secondCharacterMovement.MoveSecondCharacter(movement, up, isFirstPlayer);
        

        characterMovement.OpenMenu(Input.GetKeyDown(KeyCode.Escape));
        
    }



}
