using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DsDialog : MonoBehaviour
{

    public TextMeshProUGUI dialog;
    [SerializeField] GameObject trigger;
    public bool destroyTrigger;
    private bool text = false;
    public string text1;
    public int delay1;
    public string text2;
    public int delay2;
    public string text3;
    public int delay3;
    public string text4;
    public int delay4;
    public string textEnd;

    private IEnumerator blinkCoroutine;

    public void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&text ==false)
        {
            dialog.text = text1;
            text = true;
            StartCoroutine(t1());
        }
    }

    IEnumerator t1()
    {
        yield return new WaitForSeconds(delay1);
        dialog.text = text2;
        StartCoroutine(t2());
    }
    IEnumerator t2()
    {
        yield return new WaitForSeconds(delay2);
        dialog.text = text3;
        StartCoroutine(t3());
    }
    IEnumerator t3()
    {
        yield return new WaitForSeconds(delay3);
        dialog.text = text4;
        StartCoroutine(t4());
    }
    IEnumerator t4()
    {
        yield return new WaitForSeconds(delay4);
        dialog.text = textEnd;
        text = false;
        if (destroyTrigger == true)
        {
            Destroy(trigger);
        }
    }
}


