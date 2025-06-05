using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool OnMovement;
    [SerializeField] private float speed;
    //[SerializeField] private float Vf = 10; //Velocidad Final.
    //[SerializeField] private float TimeVf = 5; //Tiempo para que llegue a la velocidad final.
    //[SerializeField] private float acceleration; //Aceleracion 
    [SerializeField] private float jumpForce;

    //private float Vi = 0; //Velocidad inicial. 
    //private float currentTime = 0;
    private bool isJump;
    [SerializeField]private Vector2 direction;
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
        //acceleration = Vf / TimeVf;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (OnMovement && isJump)
        {
            Vector3 dir = new Vector3(direction.x, rb.linearVelocity.y, direction.y);
            rb.AddForce(dir * speed);
        }
        /*if (OnMovement)
        {
            if (currentTime < TimeVf)
            {
                currentTime += Time.deltaTime;

                float velocidadActual = acceleration * currentTime;
                Vector3 dir = new Vector3(direction.x * velocidadActual, rb.linearVelocity.y, direction.y * velocidadActual);
                rb.linearVelocity = dir;
            }
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
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
