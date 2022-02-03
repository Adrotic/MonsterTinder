using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Running,
        Failure,
        Success
    }

    public State state = State.Running;
    public bool started = false;

    /*public State Update()
    {

    }
    */
    
}
