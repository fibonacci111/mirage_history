using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public static ButtonMenager1 instance;

   

    private void Awake()
    {
        instance = this;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        
        Checkpoint.TeleportToLastCheckpoint(transform);
        SceneManager.LoadScene(1);
        Checkpoint.instance.ResetCheckpoints();
    }

    public void TeleportClick()
    {
        CharacterDeath.Instance.isDeath = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
