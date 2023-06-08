using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateEnemy
{
    public EnemyAttack(Enemy enemy, State state) : base(enemy, state)
    {
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
      
    }
}
