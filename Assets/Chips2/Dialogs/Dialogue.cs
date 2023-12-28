using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_ : MonoBehaviour
{
    [SerializeField] GameObject windowDialog;
    [SerializeField] TextMeshProUGUI textDialog;
    [SerializeField] Button button;


    public string[] message;
    private int numberDialog = 0;
    [SerializeField] GameObject DeleteDialogue;
    private void Update()
    {
      
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Confined;
            
            PlayerController.Player_Singltone.Speed = 0;
           
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);

            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }
    }

    private void OnTriggerExit(Collider collision)
    {

    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
          
            DeleteDialogue.SetActive(false);
            PlayerController.Player_Singltone.Speed = (float)PlayerController.Player_Singltone.oldSpeed;
            
            Cursor.lockState = CursorLockMode.Locked; windowDialog.SetActive(false);
            numberDialog = 0;
            button.onClick.RemoveAllListeners();
        }
    }
}
