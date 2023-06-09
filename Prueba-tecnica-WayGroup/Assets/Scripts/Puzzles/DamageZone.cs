using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [Header("Trap stats")]

    [SerializeField] private float pushForce;
    [SerializeField] private int Damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                collision.gameObject.GetComponent<PlayerStats>().ResiveDamageTrap(Damage);
                Vector3 pushDirection = Vector3.up;
                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

}
