using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeoundEnabler1 : MonoBehaviour
{
    [SerializeField] GameObject sound;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
            sound.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterMovement>(out CharacterMovement characterMovement))
            sound.SetActive(false);
    }

}
