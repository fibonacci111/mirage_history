using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract float gravity { get; protected set; }
    public abstract void Enter();
    public abstract void Exit();
   
}
