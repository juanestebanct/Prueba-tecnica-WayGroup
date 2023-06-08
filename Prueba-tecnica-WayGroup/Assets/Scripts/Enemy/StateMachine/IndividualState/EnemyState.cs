using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//necesito un sphere collider o algo que me diga que el jugador esta cerca 
public class EnemyState : StateEnemy 
{
    private Transform[] routa;

    private Transform currentpath;
    private int Index;

    private NavMeshAgent navMeshAgent;

    float time = 0;
    public EnemyState(Enemy enemy, State state, Transform[] Points, NavMeshAgent navMeshAgent) : base(enemy, state)
    {
        routa = Points;
        Index = 0;
        currentpath = routa[Index];
        this.navMeshAgent = navMeshAgent;
        navMeshAgent.destination = currentpath.position;
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Caminata a puntos");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("sigue caminando aleatoriamente");

       
    }
   
    public void Walking()
    {
        float diference = Vector3.Distance(enemy.transform.position, currentpath.position);
        if (diference == 0)
        {

        }
    }

}
