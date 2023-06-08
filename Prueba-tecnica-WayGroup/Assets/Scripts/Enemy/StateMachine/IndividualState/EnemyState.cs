using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 //va de un lugar al otro on el nav mesh 
public class EnemyState : StateEnemy 
{
    private Transform[] routa;

    private Transform currentpath;
    private int Index;

    public EnemyState(Enemy enemy, State state, Transform[] Points, NavMeshAgent navMeshAgent, Transform playerTransform) : base(enemy, state)
    {
        routa = Points;
        Index = 0;
        currentpath = routa[Index];
        this.navMeshAgent = navMeshAgent;
        navMeshAgent.destination = currentpath.position;
        PlayerRefence = playerTransform;
       
    }
    #region StateEnemy fucntions
    public override void EnterState()
    {
        base.EnterState();
        currentpath = routa[Index];
        navMeshAgent.destination= currentpath.position;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Walking();
        SearchPlayer();
    }
    #endregion

    #region Private functions 
    /// <summary>
    /// el jugador va rotando entre ruta y ruta 
    /// </summary>
    private void Walking()
    {
        float diference = Vector3.Distance(enemy.transform.position, currentpath.position);
        
        if (diference <= 0.5f)
        {
           
            if (routa.Length-1 == Index) Index = 0;
            else Index++;

            currentpath = routa[Index];

            navMeshAgent.destination = currentpath.position;
           
        }
    }
    private void SearchPlayer()
    {
        float distance = Vector3.Distance(PlayerRefence.position, enemy.transform.position);

        if (distance < 6) enemy.StartMachine.ChangeState(enemy.enemyChase);
    }
    #endregion
}
