using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : State
{
    public override float gravity { get; protected set; }

    public NormalState(float gravity)
    {
        this.gravity = gravity;
    }
    public override void Exit()
    {
       
    }
    public override void Enter()
    {

    }


}
