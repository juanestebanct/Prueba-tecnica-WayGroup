using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    public StateEnemy CurrenState;
    /// <summary>
    /// Inicia el sistema de State 
    /// </summary>
    /// <param name="startingState"></param>
    public void Initailize(StateEnemy startingState )
    {
        CurrenState = startingState;
        CurrenState.EnterState();
    }
    /// <summary>
    /// Permite el cambio de State 
    /// </summary>
    /// <param name="newState">Pasa el State que se quiere usar </param>
    public void ChangeState(StateEnemy newState)
    {
        CurrenState.ExitState();
        CurrenState = newState;
        CurrenState.EnterState();
    }
}
