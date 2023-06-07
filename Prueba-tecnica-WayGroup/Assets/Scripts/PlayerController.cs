using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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

    [Header("Grap sistem ")]

    [SerializeField] private float maxDistance, timePrees, forcelaunch;
    [SerializeField] private Transform positionObjects;
    [SerializeField] private GameObject hands, objectsGrabable;
    [SerializeField] private bool isGrabable, throwable;
  
    private Rigidbody rb;
    private Transform cameraTransform;
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isGrounded = true;

        cameraTransform = Camera.main.transform;

        rb = GetComponent<Rigidbody>();
        hands.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        ViewObject();
      
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
    /// <summary>
    /// en esta funcion se analiza primero con un raycast si collisiona con un objeto en el rango que exites 
    /// luego si es un objeto agarrable, se puede agarrar este objeto,y si detecta que tienes un objeto no puedes agarra 
    /// otro objeto, cuando se agarra el objeto este se sujeta y se desactiva la gravedad, el kinetic y se pone
    /// en una direccion 
    /// </summary>
    private void ViewObject()
    {
        if (isGrabable)
        {
            Debug.Log("se lanzara el objeto");
            ThrowObject();
            return;
        }
        Debug.DrawRay(cameraTransform.position,cameraTransform.forward *maxDistance, Color.red);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,maxDistance))
        {
            if (hit.transform.tag == "Grabable" && Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("collisiono" + hit.transform);
                hands.gameObject.SetActive(true);
                hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                hit.transform.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                hit.transform.parent = positionObjects;
                hit.transform.position = positionObjects.position;

                objectsGrabable = hit.transform.gameObject;
                isGrabable =true;
            }
            
        }
    }
    /// <summary>
    /// se detecta y precionando la q lo tiras, cuando precionas el clic izq lo lanzas 
    /// cuando detecta que lo precionas mas tiempo lo lanza con mucha fuerza 
    /// </summary>
    private void ThrowObject()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("se solto ");
            DisambleObjectGrable();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //si anda precionado el boton y lo deja de precionar salta 
            timePrees += Time.deltaTime;
            Debug.Log(timePrees);
            throwable = true;
        }
        else if (throwable)
        {
            DisambleObjectGrable();
        }
        //lanzar 
    }
    /// <summary>
    /// para el funcionamiento correcto del lanzamiento se necesita cuando se lance el objeto
    /// activar la gravedad y desactivar el kinematic.Ademas tambien se calcula si se quiere 
    /// que se lance la pelota con fuerza 
    /// </summary>
    private void DisambleObjectGrable()
    {
        objectsGrabable.transform.GetComponent<Rigidbody>().useGravity = true;
        objectsGrabable.transform.parent = null;
        objectsGrabable.transform.GetComponent<Rigidbody>().isKinematic = false;
        if (throwable)
        {
            if(timePrees>2) timePrees = 2;
            objectsGrabable.transform.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * forcelaunch * timePrees, ForceMode.Impulse);
            throwable = false;
            timePrees = 0;
        }
        objectsGrabable = null;
        isGrabable = false;
        hands.gameObject.SetActive(false);
    }
    #endregion
}
