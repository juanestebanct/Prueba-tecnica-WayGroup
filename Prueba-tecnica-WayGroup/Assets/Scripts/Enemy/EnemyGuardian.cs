using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardian : Enemy
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(positionDamageZone.position, rangeDamage);
    }
}
