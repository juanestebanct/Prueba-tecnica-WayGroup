using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    /// <summary>
    /// Reduce la salud del cuando lo colisione un objeto
    /// </summary>
    /// <param name="Force">La fuerza o la cantidad de daño que realizada el objeto coliccione con el jugador </param>
    public void LostHealth(float Force);
    /// <summary>
    /// Interface  de muerte 
    /// </summary>
    public void Dead();
    /// <summary>
    /// Interface  de ataque 
    /// </summary>
    public void Attack();
}
