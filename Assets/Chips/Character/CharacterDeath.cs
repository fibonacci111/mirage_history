using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDeath : MonoBehaviour
{
    [SerializeField] float DeathHeight;
    
    public static CharacterDeath Instance;
    [NonSerialized] public bool isDeath;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RespawnPlayer();
        SecondCharacterMovement.instance.SetCamera();
    }

    void Update()
    {
        GravityDeath();
    }
    public void RespawnPlayer() => PlayerPrefs.SetInt("IsRestarted", 1);

    private void FixedUpdate()
    {

        if (PlayerPrefs.GetInt("IsRestarted", 0) == 1)
        {
            Checkpoint.TeleportToLastCheckpoint(transform);
            PlayerPrefs.SetInt("IsRestarted", 0);
        }

    }
    public void GravityDeath()
    {
        

        if (CharacterMovement.Instance.velosity.y <= DeathHeight)
            isDeath = true;
        else
            isDeath = false;

        if (CharacterMovement.Instance.isGround && isDeath)
        {
            if (!CharacterMovement.Instance.UmbrellaIsOpen)
                KillPlayer();
            else
                isDeath = false;
        }

    }

    
    public void KillPlayer()
    {
        RespawnPlayer(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
    

}
