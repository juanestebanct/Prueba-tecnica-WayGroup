using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed : MonoBehaviour
{
    [Header("Damage Staticts")]
    [SerializeField] private float Velocity;
    [SerializeField] private float recordableDamage;
    
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Daño a los enemigos"+rb.velocity.magnitude * recordableDamage);
            collision.gameObject.GetComponent<Enemy>().LostHealth(rb.velocity.magnitude * recordableDamage);
        }
    }
}
