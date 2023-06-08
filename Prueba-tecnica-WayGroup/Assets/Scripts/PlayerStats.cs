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
    public void ResiveDamage(int Damage)
    {
        if (CanResiveDamage)
        {
            StartCoroutine(ApplyDamageOverTime());
            Debug.Log("recivio el player damge");
            Live -= Damage;

            if(Live <=0 ) Dead();
        }
    }
    private void Dead()
    {
        Debug.Log("se murio");
    }
    private IEnumerator ApplyDamageOverTime()
    {
        CanResiveDamage = false;
        yield return new WaitForSeconds(timeInMortality);
        CanResiveDamage = true;

    }
}
