using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamage
{
    [Header("enemy stats ")]

    public float Damage;

    public int Maxlive;

    public NavMeshAgent navMeshAgent;

    #region  machine variables

    public State StartMachine;

    public EnemyAttack enemyAttack;

    public EnemyState enemyState;

    public EnemyChase enemyChase;


    #endregion

    [SerializeField] private Transform[] route;
    [SerializeField] private float speed;
    [SerializeField] private float timeCouldown;
    [SerializeField] private float rangeZonaDamage;
    [SerializeField] private GameObject body;

    [Header("Speher Damage ")]

    [SerializeField] protected Transform positionDamageZone;
    [SerializeField] protected float rangeDamage;
    [SerializeField] protected LayerMask layerPlayer;

    private Rigidbody rb;
    private Vector3 randomPosition;
    private Transform Player;
    private Animator animator;

    private void Awake()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        StartMachine = new State();

        enemyAttack = new EnemyAttack(this, StartMachine, speed,Player, navMeshAgent,timeCouldown, positionDamageZone, rangeDamage, layerPlayer, rangeZonaDamage);
        enemyState = new EnemyState(this, StartMachine, route, navMeshAgent, Player);
        enemyChase = new EnemyChase(this, StartMachine, Player, navMeshAgent, rangeZonaDamage);

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartMachine.Initailize(enemyState);
        animator = body.GetComponent<Animator>();
    }
    private void Update()
    {
        StartMachine.CurrenState.UpdateState();
    }
    public void MoveEnemy()
    {
        Vector3 direction = transform.position- randomPosition;
        rb.velocity = direction.normalized * 5;

    }
    public void Dead()
    {
     
    }
    public void LostHealth(float Force)
    {
       Maxlive -=(int)Force;
    }

    public void Attack()
    {
        Debug.Log("atacando");
        animator.SetTrigger("Attack");
    }

   
    //activamos un esferecollider y si choca daña al jugador 
}
