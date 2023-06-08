using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class EnemyChase : StateEnemy
{
    private GameObject Player;
    private Rigidbody rb;
    public EnemyChase(Enemy enemy, State state) : base(enemy, state)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("jugador localizado");
        rb= enemy.GetComponent<Rigidbody>();
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
        Vector3 direction = (Player.transform.position - enemy.transform.position).normalized;

        
        enemy.transform.forward = new Vector3(direction.x, 0, direction.z).normalized;

        Debug.Log(Player.transform.position);
        float distance = Vector3.Distance (Player.transform.position, enemy.transform.position); 
       
        if (distance <= 2 )
        {
            enemy.StartMachine.ChangeState(enemy.enemyAttack);
        }
        rb.velocity = direction *2f;

    }
}
