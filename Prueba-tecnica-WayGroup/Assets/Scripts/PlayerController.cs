using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Riggibody stactic")]

    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;

    [SerializeField] private float DawnInGround;
    [SerializeField] private float DawnInAir;

    [Header("Raycast")]

    [SerializeField] private float GroundDistance;
    [SerializeField] private Transform pointReference;
    [SerializeField] private LayerMask layerGround;

    private Rigidbody rb;
    private Transform cameraTransform;
    public bool isGrounded;
    void Start()
    {
        isGrounded = true;

        cameraTransform = Camera.main.transform;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
       
    }
    #region Private fuctions 
   /// <summary>
   /// Funcion que permite el movimiento 
   /// </summary>
    private void Move()
    {
        if (isGrounded) rb.drag = DawnInGround;
        else rb.drag = DawnInAir;
    
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;
        rb.AddForce(movement*Speed*10f);

    }
    /// <summary>
    /// funcion de calcular el salto 
    /// </summary>
    private void Jump()
    {
        isGrounded = TouchGround();
        if (Input.GetButtonDown("Jump") && isGrounded) 
        { 
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse); 
        }
    }
    /// <summary>
    /// Revisa si colllisiona con el suelo 
    /// </summary>
    private bool TouchGround()
    {
        return Physics.Raycast(pointReference.position,Vector3.down, GroundDistance, layerGround);
    }

    #endregion
}
