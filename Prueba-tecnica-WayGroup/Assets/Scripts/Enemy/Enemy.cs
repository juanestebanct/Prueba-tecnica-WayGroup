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

    [SerializeField] Transform[] route;
    private Rigidbody rb;
    private Vector3 randomPosition;


    private void Awake()
    {
        StartMachine = new State();

        enemyAttack = new EnemyAttack(this, StartMachine);
        enemyState = new EnemyState(this, StartMachine, route, navMeshAgent);
        enemyChase = new EnemyChase(this, StartMachine);

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartMachine.Initailize(enemyState);
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
}
