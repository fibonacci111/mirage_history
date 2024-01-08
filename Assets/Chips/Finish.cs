using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finish;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            finish.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
