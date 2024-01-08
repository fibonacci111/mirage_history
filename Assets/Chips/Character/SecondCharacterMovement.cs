using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCharacterMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float Speed;
    [SerializeField] SmoothMovement smoothMovement;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject camera2;
    bool IsSecondPlayer;
    bool a;

    public static SecondCharacterMovement instance;
    private void Start()
    {
        instance = this;
        SetCamera();
    }
    public void MoveSecondCharacter(Vector3 moveDirection, float up, bool isSecondPlayer)
    {
        IsSecondPlayer = isSecondPlayer;
        if (!IsSecondPlayer)
        {
            camera.SetActive(false);
            camera2.SetActive(true);
            smoothMovement.enabled = false;
            Vector3 moveUp = new Vector3(0, up, 0);

            characterController.Move(moveDirection * Speed * Time.deltaTime);
            characterController.Move(moveUp * Speed * Time.deltaTime);
        }
        else
        {
            camera.SetActive(true);
            camera2.SetActive(false);
            smoothMovement.enabled = true;
        }
    }
    public void SetCamera()
    {
       StartCoroutine(SetCameraActive());
    }
    IEnumerator SetCameraActive()
    {
        yield return new WaitForSeconds(0.01f);
        camera.SetActive(false);
        camera2.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        camera.SetActive(true);
        camera2.SetActive(false);
    }

}
