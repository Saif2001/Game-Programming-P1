using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public States currentState;
    // Update is called once per frame
    void Update()
    {
        RunSM();
    }

    private void RunSM()
    {
        States nextState = currentState?.RunCurrentState();

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
