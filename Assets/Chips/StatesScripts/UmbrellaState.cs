using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UmbrellaState :  State
{
   
    MonoBehaviour _monoBehaviour;
    LayerMask _layerMask;
    Coroutine _coroutine;
    
    public override float gravity { get; protected set; }
    public float _windGravity { get; }
    public float Radius { get; }

    private float UmbrellaGravity;
    

    public UmbrellaState(float gravity,float windGravity,float radius, MonoBehaviour monoBehaviour, LayerMask layerMask)
    {
      this.gravity = gravity; 
        _windGravity = windGravity;
        Radius = radius;
        _monoBehaviour = monoBehaviour;
        _layerMask = layerMask;
        UmbrellaGravity = this.gravity;
    }

    public override void Enter()
    {
        _coroutine = _monoBehaviour.StartCoroutine(WindDetect());
    }
    public override void Exit()
    {
        _monoBehaviour.StopCoroutine(_coroutine);
    }

    IEnumerator WindDetect()
    {
        while (_monoBehaviour.enabled)
        {
            if (Physics.CheckSphere(_monoBehaviour.transform.position, 0.5f, _layerMask, QueryTriggerInteraction.Collide)) 
            {
                gravity = _windGravity;
            }
            else
            {
                gravity = UmbrellaGravity;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}

