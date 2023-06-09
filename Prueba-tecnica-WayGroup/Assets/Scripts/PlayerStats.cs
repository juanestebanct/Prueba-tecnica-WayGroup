using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]

    [SerializeField] private float maxLive;
    [SerializeField] private float live;
    [SerializeField] private float MaxSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float points;
    [SerializeField] private float timeInMortality;
    [SerializeField] private PlayerController MovenPlayer;

    private bool CanResiveDamage;

    private void Start()
    {
        speed = MaxSpeed;
        MovenPlayer.ChangeSpeed(MaxSpeed);
        CanResiveDamage = true;
        live = maxLive;
    }
    #region private Funtions 
    /// <summary>
    /// Se calcula el da�o que recibe el jugador
    /// </summary>
    /// <param name="Damage"></param>
    public void ResiveDamage(int Damage)
    {
        if (CanResiveDamage)
        {
            StartCoroutine(ApplyDamageOverTime());
            live -= Damage;

            if(live <=0 ) Dead();
        }
    }
    public void ResiveHealt(float healt)
    {
        live+= healt;
        if (live > maxLive) live = maxLive;
    }
    
    public void ChangeSpeed(float speed)
    {
        Debug.Log("aplico la velocidad ");
        this.speed += speed;
        Debug.Log(this.speed);
        MovenPlayer.ChangeSpeed(this.speed);
        StartCoroutine(ApplicateSpeed());
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
    private IEnumerator ApplicateSpeed()
    {
        Debug.Log("mejoro la velocidad");
        yield return new WaitForSeconds(3);
        speed = MaxSpeed;
        MovenPlayer.ChangeSpeed(speed);
    }
    #endregion
}
