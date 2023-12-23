using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform camera;
    [SerializeField] Transform text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.LookAt(camera);
    }
}
