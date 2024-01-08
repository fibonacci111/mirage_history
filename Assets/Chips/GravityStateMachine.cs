using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityStateMachine 
{
    public State CurrentState { get; private set; }
    public void SetState(State state)
    {
        if(CurrentState!=null)
            CurrentState.Exit();

        CurrentState = state;
        CurrentState.Enter();
    }

}
