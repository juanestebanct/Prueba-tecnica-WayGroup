using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Moven Stact Enemy")]

    [SerializeField] private Transform[] route;
    [SerializeField] private float speed;
    [SerializeField] private float timeCouldown;
    [SerializeField] private float rangeZonaDamage;
    [SerializeField] private GameObject body;
    [SerializeField] private float minDamageRequired;
    [SerializeField] private float maxRangeChase;

    [Header("Speher Damage ")]

    [SerializeField] protected Transform positionDamageZone;
    [SerializeField] protected float rangeDamage;
    [SerializeField] protected LayerMask layerPlayer;

    private Transform Player;
    private Animator animator;

    private void Awake()
    {

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        StartMachine = new State();

        enemyAttack = new EnemyAttack(this, StartMachine, speed,Player, navMeshAgent,timeCouldown, positionDamageZone, rangeDamage, layerPlayer, rangeZonaDamage);
        enemyState = new EnemyState(this, StartMachine, route, navMeshAgent, Player, maxRangeChase);
        enemyChase = new EnemyChase(this, StartMachine, Player, navMeshAgent, rangeZonaDamage, maxRangeChase);

    }
    private void Start()
    {
        StartMachine.Initailize(enemyState);
        animator = body.GetComponent<Animator>();
    }
    private void Update()
    {
        StartMachine.CurrenState.UpdateState();
    }
    #region public funtions 
    /// <summary>
    ///  Aplicación de la interfaz de la muerte activada  
    /// </summary>
    public void Dead()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Aplicación de la interfaz de perdida de vida  
    /// </summary>
    public void LostHealth(float Force)
    {
        if (Force < minDamageRequired) return;
        Maxlive -=(int)Force;
        if (Maxlive <= 0) Dead();
    }
    /// <summary>
    /// Se ejecuta la animación
    /// </summary>
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    #endregion
}
