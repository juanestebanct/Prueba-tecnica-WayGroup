using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [Header("Force")]

    [SerializeField] private float pushForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pushDirection = transform.forward + Vector3.up;
                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

}
