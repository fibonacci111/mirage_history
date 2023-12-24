using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogOnE : MonoBehaviour
{
    [SerializeField] GameObject windowDialog;
    [SerializeField] TextMeshProUGUI textDialog;
    [SerializeField] Button button;


    bool look;
    public string[] message;
    private int numberDialog = 0;
    // [SerializeField] GameObject DeleteDialogue;
    bool enter = false;

   
    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Confined;
            look = true;

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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            enter = true;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        enter = false;
        windowDialog.SetActive(false);
        numberDialog = 0;
       
        button.onClick.RemoveAllListeners();
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
            look = false;
            // DeleteDialogue.SetActive(false);
            
           
            Cursor.lockState = CursorLockMode.Locked;
           
        }
    }
}
