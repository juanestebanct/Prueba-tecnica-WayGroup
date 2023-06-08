using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateEnemy 
{
    protected Enemy enemy;
    protected State state;
    protected Transform PlayerRefence;
    protected NavMeshAgent navMeshAgent;
    protected float speed;
    public StateEnemy(Enemy enemy, State state)
    {
        this.enemy = enemy;
        this.state = state;
    }
    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}
