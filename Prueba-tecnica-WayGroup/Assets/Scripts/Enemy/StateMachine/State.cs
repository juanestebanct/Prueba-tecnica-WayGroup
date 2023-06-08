using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    public StateEnemy CurrenState;

    public void Initailize(StateEnemy startingState )
    {
        CurrenState = startingState;
        CurrenState.EnterState();
    }
    public void ChangeState(StateEnemy newState)
    {
        CurrenState.ExitState();
        CurrenState = newState;
        CurrenState.EnterState();
    }
}
