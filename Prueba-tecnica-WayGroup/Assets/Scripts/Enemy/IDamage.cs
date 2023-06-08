using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    public void LostHealth(float Force);

    public void Dead();

    public void Attack();
}
