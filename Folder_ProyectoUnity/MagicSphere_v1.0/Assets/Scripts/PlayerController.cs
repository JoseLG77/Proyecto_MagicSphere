using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool OnMovement;
    //[SerializeField] private float speed;
    [SerializeField] private float velocityMax = 5; //Velocidad Final.
    [SerializeField] private float acceleration = 5; //Tiempo para que llegue a la velocidad final.
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform checkPoint;

    //private float Vi = 0; //Velocidad inicial. 
    //private float currentTime = 0;
    private bool isJump;
    private Vector2 direction;
    private Vector2 directionVelocityMax;
    private Vector2 directionCurrentVelocity;
    private Rigidbody rb;

    /*public float CurrentTime
    {
        set
        {
            if (value > TimeVf) return;
            currentTime = value;
        }
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionVelocityMax = new Vector2(velocityMax, velocityMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        /*if (OnMovement && isJump)
        {
            Vector3 dir = new Vector3(direction.x, rb.linearVelocity.y, direction.y);
            rb.AddForce(dir * speed);
        }*/
        if (OnMovement)
        {
            directionCurrentVelocity +=  direction * acceleration * Time.deltaTime;
            
            directionCurrentVelocity.x = Mathf.Clamp(directionCurrentVelocity.x, -directionVelocityMax.x, directionVelocityMax.x);
            directionCurrentVelocity.y = Mathf.Clamp(directionCurrentVelocity.y, -directionVelocityMax.y, directionVelocityMax.y);
            //Mathf.Clamp es una funciones de unity, la cual limita un valor dentro de un rango minimo y maximo

            Vector3 mov = new Vector3(directionCurrentVelocity.x, rb.linearVelocity.y, directionCurrentVelocity.y);
            rb.linearVelocity = mov;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
        if (collision.gameObject.CompareTag("Limit"))
        {
            OnMovement = false;
            rb.linearVelocity = Vector3.zero;
            transform.position = checkPoint.position;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isJump)
        {
            rb.AddForce(Vector3.up * 100 * jumpForce);
        }
    }
}
