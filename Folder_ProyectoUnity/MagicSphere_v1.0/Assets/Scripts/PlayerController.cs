using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool OnMovement;
    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpForce;

    private Vector2 direction;
    private bool isJump;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
