using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void SetState(State state)
    {
        currentState = state;
        currentState.OnEnter();
    }
}
