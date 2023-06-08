using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : StateEnemy
{
    private float AttactTime;
    private float timeCountdown;
    private float rangezoneAttack;

    private Transform positionDamageZone;
    private float rangeDamage;
    private LayerMask layerPlayer;
    private int Damage;
    private GameObject Player;
    public EnemyAttack(Enemy enemy, State state ,float speed, Transform playerTransform, NavMeshAgent navMeshAgent,float _timeCountdown,Transform PositionDamageZone,float RangeDagame, LayerMask LayerPlayer
        ,float RangeZonaDamage) 
        : base(enemy, state)
    {
        PlayerRefence = playerTransform;
        this.speed = speed;
        this.navMeshAgent = navMeshAgent;
        timeCountdown = _timeCountdown;
        AttactTime = timeCountdown;

        positionDamageZone = PositionDamageZone;
        rangeDamage = RangeDagame;
        layerPlayer = LayerPlayer;
        rangezoneAttack = RangeZonaDamage;
        Player = GameObject.FindGameObjectWithTag("Player");
        Damage = 20;
    }
    #region StateEnemy fucntions
    public override void EnterState()
    {
        base.EnterState();
        enemy.Attack();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Attack();
        AttactAccion();

    }
    #endregion

    #region Privete fucntions
    private void Attack()
    {
        float distance = Vector3.Distance(PlayerRefence.position, enemy.transform.position);

        if (distance > rangezoneAttack)
        {
            ResumeMoving();
            enemy.StartMachine.ChangeState(enemy.enemyChase);
        }
        else
        {
            if (Physics.CheckSphere(positionDamageZone.position,rangeDamage, layerPlayer))
            {
                Player.GetComponent<PlayerStats>().ResiveDamage(Damage);
            }
        }
    }
    /// <summary>
    /// Activa de nuevo el movimiento del enemigo después de atacar
    /// </summary>
    private void ResumeMoving()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;

    }
    /// <summary>
    /// Se encarga de ejecutar la animacion cada cierto tiempo
    /// </summary>
    private void AttactAccion()
    {
        AttactTime -= Time.deltaTime;
        if (AttactTime <= 0)
        {
            enemy.Attack();
            AttactTime = timeCountdown;
        }
    }

    #endregion
}
