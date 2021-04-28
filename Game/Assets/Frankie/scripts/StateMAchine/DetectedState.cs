using AI.Agent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachine/States/Detected")]

public class DetectedState : State
{
    public AttackState attackState;
    public PursueState pursueState;
    public IdleState IdleState;
    public override State RunCurrentState(GuardAgent agent, Animator animator)
    {
        //change this to 
        //if 1 turn has passed and player is still seen, 
        //if player is close then attack
        //else pursue
        //else if 1 turn has passed and the player is hiden then enter search state
        
        agent.ViewConeColor = Color.red;
        if (agent.ATTACKTEST == true)
        {
            return pursueState;
        }
        else
        {
            return this;
        }
        
    }
}
