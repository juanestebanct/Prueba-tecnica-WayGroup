using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : StateEnemy
{
    
    public EnemyAttack(Enemy enemy, State state ,float speed, Transform playerTransform, NavMeshAgent navMeshAgent) : base(enemy, state)
    {
        PlayerRefence = playerTransform;
        this.speed = speed;
        this.navMeshAgent = navMeshAgent;
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("se fue a atacar");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Attack();

    }
    private void Attack()
    {
        float distance = Vector3.Distance(PlayerRefence.position, enemy.transform.position);
        if (distance > 3 )
        {
            ResumeMoving();
            Debug.Log("cambia a enemychase");
            enemy.StartMachine.ChangeState(enemy.enemyChase);
        }
        else Debug.Log("sigue atacando");
    }

    private void ResumeMoving()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
        // Establece otros parámetros como el radio de frenado, aceleración, etc., según sea necesario.
    }
}
