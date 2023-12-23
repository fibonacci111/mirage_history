using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//public interface GravityController
//{
//    public abstract void Gravity();
//}

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] GameObject camera2;
    [SerializeField] SmoothMovement smoothMovement;
    [SerializeField] GameObject Menu;
    [SerializeField] Transform playerPosition;
    [SerializeField] CharacterController cc;
    [SerializeField] CharacterController cc2;
    [SerializeField] float Speed = 10f;
    private float? oldSpeed = null;
    [SerializeField] float Sprint = 15f;
    public float stamina = 10f;
    [SerializeField] Image staminaCanvas;
    private float timerStamina = 0f;
    [SerializeField] float TimeStart = 2f;
    private bool isRun = true;
    [SerializeField] float LadderSpeed = 5f;
    [SerializeField] float RotateSpeed = 5f;
    public float JumpHeight = 10f;
    [NonSerialized] public float? oldJumpHeight = null;
    private Vector3 moveDirection;
    [SerializeField] GameObject PlayerBody;
   
    private bool isCrouching = false;
    private bool isSliding = false;
    public float slideSpeed = 5.0f; 
    public float slideDuration = 2.0f; 
    private float slideTimer = 0.0f;
    public float crouchRecoverTime = 1.5f; // Время восстановления после приседания
    private float crouchRecoverTimer = 0.0f;
    public float SlideHeight;
    public float NormalHeight = 2;

    private bool switchd;
    private bool a = false;
    private bool onWind;
    private bool isMenuOpen = true;
    private bool IsFirstPlayer = true;

    public float gravity = -9.81f;
    [NonSerialized] public float? staticGravity = null;
    public float umbrellaGravity = -0.5f;
    public float windGravity = 10;

    [NonSerialized] public bool umbrellaIsOpen;
    [NonSerialized] public bool umbrellaOnWind;
    public bool LadderEnter;

    [SerializeField] float DeathHeight;

    Vector3 velosity;

    [SerializeField] GroundChecker ground;
    [SerializeField] Umbrella umbrella;
    public static PlayerController Player_Singltone;
   
    [NonSerialized] public bool death;
    private void Awake()
    {
        Singl();
        
    }
    public void Singl()
    {
        Player_Singltone = this;
        
    }

    private void Start()
    {
        if (staticGravity == null)
        {
            staticGravity = gravity;
            oldJumpHeight = JumpHeight;
            oldSpeed = Speed;

        }
        Time.timeScale = 1;
        RespawnPlayer();
        
    }


    void Update()
    {
        if (IsFirstPlayer) { 
         Wind();
        staminaCanvas.fillAmount = 1 - (timerStamina / stamina);

        if (Input.GetKey(KeyCode.LeftShift) && timerStamina <= stamina && isRun && ground._IsGround())
        {
            Speed = Sprint;
            timerStamina += 1f * Time.deltaTime;
            isRun = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || timerStamina >= stamina || !ground._IsGround())
        {
            isRun = false;
        }
        if (!isRun)
        {
            Speed = (float)oldSpeed;
            if (timerStamina >= 0)
            {
                timerStamina -= 1f * Time.deltaTime;
            }
            else if (timerStamina < TimeStart)
            {
                isRun = true;
            }

        }
        ground._IsGround();
        if (!LadderEnter)
        {
            Gravity();
        }
        if (!isSliding)
        {
            Controller();
        }
        if (umbrellaIsOpen)
        {
            JumpHeight = umbrella.UmbrellaJumpHeight;
        }
        else
        {
            JumpHeight = (float)oldJumpHeight;
        }
        if (Input.GetButtonDown("Jump") && ground._IsGround())
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!switchd)
            {

                umbrella.OpenUmbrella();
                switchd = true;
                umbrellaIsOpen = true;
            }
            else if (switchd)
            {
                umbrella.CloseUmbrella();
                switchd = false;
                umbrellaIsOpen = false;
            }
        }

        if (death)
        {
            PlayerPrefs.SetInt("IsRestarted", 1); // Сохраняем флаг перезапуска
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftShift) && isRun && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            isCrouching = true;
            isSliding = true;
            slideTimer = slideDuration;
        }
        if (isCrouching)
        {
            if (crouchRecoverTimer > 0)
            {
                crouchRecoverTimer -= Time.deltaTime;

                if (crouchRecoverTimer <= 0)
                {
                    isCrouching = false;
                }
            }
        }
            if (isSliding)
            {
                if (slideTimer > 0)
                {
                    slideTimer -= Time.deltaTime;
                    Vector3 slideDirection = PlayerBody.transform.forward.normalized;
                    cc.Move(slideDirection * slideSpeed * Time.deltaTime);
                    cc.height = SlideHeight;

                    if (slideTimer <= 0)
                    {
                        isSliding = false;
                        isCrouching = true;
                        crouchRecoverTimer = crouchRecoverTime;
                    }
                }

               
            } else if(!isSliding)
                {
                    cc.height = NormalHeight;
                }
            
              
    }else if(!IsFirstPlayer)
            {
                float vertical = Input.GetAxisRaw("Vertical");
                float horizontal = Input.GetAxisRaw("Horizontal");
                float up = 0;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    up = 1;
                }else if (Input.GetKey(KeyCode.LeftAlt))
                {
                    up = -1;
                }
                else
                {
                    up = 0;
                }
                Vector3 moveDirection = (vertical * transform.forward + horizontal * transform.right).normalized;
                Vector3 moveUp = new Vector3(0, up, 0);
                    cc2.Move(moveDirection * Speed * Time.deltaTime);
                    cc2.Move(moveUp * Speed * Time.deltaTime);
              
              

            }
         if (IsFirstPlayer && Input.GetKeyDown(KeyCode.Tab))
              {
            camera.SetActive(false);
            camera2.SetActive(true);
                    IsFirstPlayer = false;
                cc.enabled = false;
                cc2.enabled = true;
                smoothMovement.enabled = false;
              }else if(!IsFirstPlayer && Input.GetKeyDown(KeyCode.Tab))
               {
            camera.SetActive(true);
            camera2.SetActive(false);
                    IsFirstPlayer = true;
                cc.enabled = true;
                cc2.enabled = false;
                smoothMovement.enabled = true;
            }     OpenMenu();
    }
    public void RespawnPlayer()=> PlayerPrefs.SetInt("IsRestarted", 1);
    private void FixedUpdate()
    {

        if (PlayerPrefs.GetInt("IsRestarted", 0) == 1)
        {
            Checkpoint.TeleportToLastCheckpoint(transform);
            PlayerPrefs.SetInt("IsRestarted", 0); 
        }

    }
   private void OpenMenu()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape)&&isMenuOpen)
        {
            Menu.SetActive(true);
            isMenuOpen = false;
        }else if(Input.GetKeyDown(KeyCode.Escape) && isMenuOpen)
        {
            Menu.SetActive(false);
            isMenuOpen = true;
        }

    }

    private void Controller()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = (vertical * transform.forward + horizontal * transform.right).normalized;
        Vector3 inputDir = new Vector3(horizontal, 0, vertical).normalized;

        if (inputDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            float rotationSpeed = RotateSpeed * Time.deltaTime;
            PlayerBody.transform.rotation = Quaternion.Lerp(PlayerBody.transform.rotation, targetRotation, rotationSpeed);
        }
        Vector3 ladder = new Vector3(0, vertical, 0);
        Vector3 horMove = new Vector3(horizontal, 0, 0);
            if (!LadderEnter)
            {
             cc.Move(moveDirection * Speed * Time.deltaTime);
            
            }else if (LadderEnter)
            {
             cc.Move(horMove *  Speed * Time.deltaTime);
             cc.Move(ladder * LadderSpeed * Time.deltaTime); 
            }
    }
   public void Gravity()
    {
        bool aa = false;
        if (velosity.y <= DeathHeight)
        {
            aa = true;
        }
        if (aa && ground._IsGround())
        {
            death = true;
            //Debug.Log("sadfasdfasd");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Checkpoint.TeleportToLastCheckpoint(playerPosition.transform);
        }
        
        if (ground._IsGround() && velosity.y < 0 &&!umbrellaIsOpen)
        {
            velosity.y = -2f;
        }
       
        if(umbrellaIsOpen && !ground._IsGround() && !umbrellaOnWind)
        {
            if (!a)
            {
                velosity.y = 0;
                a = true;
                
            }            
            velosity.y += umbrellaGravity * Time.deltaTime;
           
        }

        if(ground._IsGround()||!umbrellaIsOpen)
        {
            a = false;
        }
        
        if (umbrellaOnWind&& umbrellaIsOpen)
        {
            velosity.y += gravity * Time.deltaTime;

        }

        if (!umbrellaIsOpen)
        {
            velosity.y += gravity * Time.deltaTime;
            
        }
        cc.Move(velosity * Time.deltaTime);
    }
    public void Jump()
    {
        if (ground._IsGround())
        {
            velosity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            
        }
    }
    public void Wind()
    {

        if (onWind && umbrellaIsOpen)
        {
            gravity = windGravity;
            umbrellaOnWind = true;
        }
        else if (!onWind && umbrellaIsOpen)
        {
            gravity = (float)staticGravity;
            umbrellaOnWind = false;

        }
        if (!umbrellaIsOpen)
        {
            gravity = (float)staticGravity;
            umbrellaOnWind = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wind"))
        {
            onWind = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wind"))
        {
            onWind = false;
        }
    }
    public void ResetPlayerState()
    {
       gravity  = (float)staticGravity;
        JumpHeight = (float)oldJumpHeight;
       
        umbrellaIsOpen = false;
        umbrellaOnWind = false;
       
    }

}




[Serializable]
public class GroundChecker
{
    public Transform GroundCheck;
    public float GroundDistanse = 0.4f;
    public LayerMask Ground;
    [NonSerialized] public static bool isGround;
    public bool _IsGround()=> isGround = Physics.CheckSphere(GroundCheck.position, GroundDistanse, Ground);
}

[Serializable]
public class Umbrella
{
    [SerializeField] GameObject umbrella;
    public float UmbrellaJumpHeight;
   

   public void OpenUmbrella()
    {
        umbrella.SetActive(true);

    }
    public void CloseUmbrella()
    {
        umbrella.SetActive(false);
        
    }

   
}

