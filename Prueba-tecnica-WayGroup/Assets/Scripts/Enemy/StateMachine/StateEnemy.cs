using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEnemy 
{
    protected Enemy enemy;
    protected State state;
    public StateEnemy(Enemy enemy, State state)
    {
        this.enemy = enemy;
        this.state = state;
    }
    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}
