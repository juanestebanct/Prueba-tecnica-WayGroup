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
    #region Virtual fucntions
    /// <summary>
    /// Cuando entra en este state
    /// </summary>
    public virtual void EnterState() { }
    /// <summary>
    /// Cuando esta en este state
    /// </summary>
    public virtual void UpdateState() { }
    /// <summary>
    /// Cuando sale del este state
    /// </summary>
    public virtual void ExitState() { }

    #endregion
}
