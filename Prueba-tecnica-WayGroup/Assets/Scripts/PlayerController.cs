using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [Header("Rigidbody stactic")]

    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;

    [SerializeField] private float DawnInGround;
    [SerializeField] private float DawnInAir;

    [Header("Raycast")]

    [SerializeField] private RaycastHit hitInfo;
    [SerializeField] private float GroundDistance;
    [SerializeField] private Transform pointReference;
    [SerializeField] private LayerMask layerGround;

    [Header("Grab sistem ")]

    [SerializeField] private Image force;
    [SerializeField] private GameObject forceBar;
    [SerializeField] private float maxDistance, timePrees, forcelaunch, maxTime;
    [SerializeField] private Transform positionObjects;
    [SerializeField] private GameObject hands, objectsGrabable;
    [SerializeField] private bool isGrabbed, throwable;
  
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

        forceBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        DetectObject();
    }

    #region Public fuctions 
    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }
    #endregion

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
        rb.AddForce(movement*speed*10f);

        Vector3 clampedVelocity = rb.velocity;

        // se compureba si hay un movimiento, si no se quita la velocidad
        if (movement.magnitude != 0)
        {
            clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -speed, speed);
            clampedVelocity.z = Mathf.Clamp(clampedVelocity.z, -speed, speed);
        }
        else
        {
            clampedVelocity.x = 0;
            clampedVelocity.z = 0;
        }
        ///limite de velocidad 
        rb.velocity = clampedVelocity;

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
    private void DetectObject()
    {
        if (isGrabbed)
        {
            DestroyObjectGrab();
            ThrowObject();
            return;
        }

        Debug.DrawRay(cameraTransform.position,cameraTransform.forward *maxDistance, Color.red);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,maxDistance))
        {
            if (hit.transform.tag == "Grabbed" && Input.GetKeyDown(KeyCode.Mouse0))
            {

                hands.gameObject.SetActive(true);
                Rigidbody temRb = hit.transform.GetComponent<Rigidbody>();

                temRb.velocity = Vector3.zero;
                temRb.useGravity = false;
                temRb.isKinematic = true;
                hit.transform.GetComponent<Collider>().enabled = false;
                hit.transform.parent = positionObjects;
                hit.transform.position = positionObjects.position;

                objectsGrabable = hit.transform.gameObject;
                isGrabbed =true;
                forceBar.gameObject.SetActive(true);
            }
            
        }
    }
    /// <summary>
    /// si colocas un objeto y este se destruye, se desactiva el agarre
    /// </summary>
    private void DestroyObjectGrab()
    {
        if (objectsGrabable == null)
        {
            objectsGrabable = null;
            hands.gameObject.SetActive(false);
            isGrabbed = false;
            forceBar.gameObject.SetActive(false);
            return;
        }
    }
    /// <summary>
    /// se detecta y precionando la q lo tiras, cuando precionas el clic izq lo lanzas 
    /// cuando detecta que lo precionas mas tiempo lo lanza con mucha fuerza 
    /// </summary>
    private void ThrowObject()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DropGrabbed();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
          
            //si anda precionado el boton y lo deja de precionar salta 
            timePrees += Time.deltaTime;
            throwable = true;
            force.fillAmount= timePrees / maxTime;
        }
        else if (throwable)
        {
            DropGrabbed();
        }
        //lanzar 
    }
    /// <summary>
    /// para el funcionamiento correcto del lanzamiento se necesita cuando se lance el objeto
    /// activar la gravedad y desactivar el kinematic.Ademas tambien se calcula si se quiere 
    /// que se lance la pelota con fuerza 
    /// </summary>
    private void DropGrabbed()
    {
        Rigidbody temRb = objectsGrabable.transform.GetComponent<Rigidbody>();
        temRb.useGravity = true;
        objectsGrabable.transform.parent = null;
        objectsGrabable.GetComponent<Collider>().enabled = true;   
        temRb.isKinematic = false;

        if (throwable)
        {
           
            if (timePrees>maxTime) timePrees = 2;
            temRb.AddForce(cameraTransform.forward * forcelaunch * timePrees, ForceMode.Impulse);
            throwable = false;
            timePrees = 0;
        }
        forceBar.gameObject.SetActive(false);
        objectsGrabable = null;
        isGrabbed = false;
        hands.gameObject.SetActive(false);
        force.fillAmount = 0;
    }
    #endregion

}
