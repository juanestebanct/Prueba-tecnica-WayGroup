using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : StateEnemy
{
    private float rangezoneAttack;
    public EnemyChase(Enemy enemy, State state, Transform playerTransform, NavMeshAgent navMeshAgent, float RangeZonaDamage) : base(enemy, state)
    {
        PlayerRefence = playerTransform;
        this.navMeshAgent = navMeshAgent;
        rangezoneAttack = RangeZonaDamage;
    }
    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base .ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Chanseplayer();
    }
    private void Chanseplayer()
    {
        float distance = Vector3.Distance(PlayerRefence.position, enemy.transform.position);
        navMeshAgent.destination = PlayerRefence.position;
        if (distance <= rangezoneAttack)
        {
            StopMoving();
            enemy.StartMachine.ChangeState(enemy.enemyAttack);
        }else if (distance >= 6)
        {
            enemy.StartMachine.ChangeState(enemy.enemyState);
        }
    }

    private void StopMoving()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.speed = 0f;
    }
   

}