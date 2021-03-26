using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public abstract class State 
{

    protected abstract StateMachine stateMachine { get; set; }

    public State(StateMachine _stateMachine)
    {
    }
    
    public abstract IEnumerator Start();
    public abstract IEnumerator End();

    public virtual void Update()
    {

    }
}
