using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Raycast")]

    [SerializeField] private float Live;
    [SerializeField] private float timeInMortality;

    private bool CanResiveDamage;

    private void Start()
    {
        CanResiveDamage = true;
    }
    #region private Funtions 
    /// <summary>
    /// Se calcula el daño que recibe el jugador
    /// </summary>
    /// <param name="Damage"></param>
    public void ResiveDamage(int Damage)
    {
        if (CanResiveDamage)
        {
            StartCoroutine(ApplyDamageOverTime());
            Live -= Damage;

            if(Live <=0 ) Dead();
        }
    }
    private void Dead()
    {
        Debug.Log("se murio");
    }
    /// <summary>
    /// Corrutina que se encarga de la inmortalidad temporal del jugador 
    /// </summary>
    /// <returns></returns>
    private IEnumerator ApplyDamageOverTime()
    {
        CanResiveDamage = false;
        yield return new WaitForSeconds(timeInMortality);
        CanResiveDamage = true;

    }
    #endregion
}
