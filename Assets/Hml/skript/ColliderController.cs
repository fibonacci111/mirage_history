using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField] Collider  col1;
    [SerializeField] Collider col2;
    void Update()
    {
       Physics.IgnoreCollision(col1, col2);
    }
}
