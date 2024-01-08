using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindState : State
{
    public override float gravity { get; protected set; }

    public WindState(float gravity)
    {
        this.gravity = gravity;
    }
    public override void Enter()
    {

    }
    public override void Exit() { }

    
}
