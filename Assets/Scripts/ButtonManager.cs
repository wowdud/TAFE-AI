using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Behaviours stateMachine;    

    public void WanderButton()
    {
        print("Wandering");
        stateMachine.state = Behaviours.State.Wander;
    }

    public void StopButton()
    {
        print("Stopped");
        stateMachine.state = Behaviours.State.Stop;
    }

}
