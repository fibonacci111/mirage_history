using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public  static ButtonMenager1 instance;
    public bool IsDelete = false;

    private void Awake()
    {
        

        instance = this;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        
    }

    // Update is called once per frame
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        Checkpoint.TeleportToLastCheckpoint(transform);
        SceneManager.LoadScene(1);
        Checkpoint.instance.ResetCheckpoints(); // —брос чекпоинтов
    }
    public void TeleportClick()
    {
        PlayerController.Player_Singltone.death = true;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
