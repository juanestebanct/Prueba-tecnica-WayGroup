using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Transform camara;

    private Rigidbody rb;

    private Vector3 moventDirection;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    #region Private fuctions 
   
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        rb.velocity = new Vector3(movement.x,0,movement.z)* Speed;

    }

    #endregion
}
