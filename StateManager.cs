using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public States currentState;

    void Update()
    {
        RunSM();
    }

    private void RunSM()
    {
        States nextState = currentState.RunCurrentState();

        if(nextState != null)
        {
            NextState(nextState);

        }
    }

    private void NextState(States nextState)
    {
        currentState = nextState;
    }
}
