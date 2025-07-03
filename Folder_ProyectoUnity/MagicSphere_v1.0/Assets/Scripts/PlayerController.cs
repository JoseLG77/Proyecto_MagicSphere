using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    #region Properties
    [Header("-----Statistics-----")]
    [SerializeField] private float velocityMax = 5; //Velocidad Final.
    [SerializeField] private float acceleration = 5; //Tiempo para que llegue a la velocidad final.
    [SerializeField] private float jumpForce;
    [Header("-----CheckPoint-----")]
    [SerializeField] private Transform checkPoint;
    [Header("-----Shape-----")]
    [SerializeField] private Mesh[] shape;
    [SerializeField] private DoublyLinkedCircularList shapeList = new DoublyLinkedCircularList();
    [SerializeField] private NodeShape currentShape;
    [SerializeField] private MeshFilter meshFilter;
    /*[Header("-----Animation-----")]
    [SerializeField] private float scaleStart = 1.0f;
    [SerializeField] private float scaleEnd = 1.0f;
    [SerializeField] private float timeDuration = 1;
    [SerializeField] private AnimationCurve curve;*/


    private bool isJump;
    private bool isPressed;
    private bool OnMovement;
    private Vector2 direction;
    private Vector2 directionVelocityMax;
    private Vector2 directionCurrentVelocity;
    private Rigidbody rb;
    #endregion

    public Transform CheckPoint
    {
        get { return checkPoint; }
        set { checkPoint = value; }
    }

    #region UnityMethods
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        directionVelocityMax = new Vector2(velocityMax, velocityMax);
        meshFilter = GetComponent<MeshFilter>();
        OnMovement = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!OnMovement) return;

        
            if (!isPressed)
            {
                if (directionCurrentVelocity == Vector2.zero)
                {
                    rb.linearDamping = 0.5f;
                    //rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, rb.linearVelocity.z);
                    return;
                }
                else
                {
                    if (directionCurrentVelocity.magnitude > 0.1f)
                    {
                        directionCurrentVelocity = Vector2.Lerp(directionCurrentVelocity, Vector2.zero, Time.deltaTime * acceleration * 0.6f);
                    }
                    else
                    {
                        directionCurrentVelocity = Vector2.zero;
                    }
                    Vector3 desaleracion = new Vector3(directionCurrentVelocity.x, rb.linearVelocity.y, directionCurrentVelocity.y);
                    rb.linearVelocity = desaleracion;
                    return;
                }
            }
            //MRUV
            directionCurrentVelocity += direction * acceleration * Time.deltaTime;

            directionCurrentVelocity.x = Mathf.Clamp(directionCurrentVelocity.x, -directionVelocityMax.x, directionVelocityMax.x);
            directionCurrentVelocity.y = Mathf.Clamp(directionCurrentVelocity.y, -directionVelocityMax.y, directionVelocityMax.y);
            //Mathf.Clamp es una funciones matematica, la cual limita un valor dentro de un rango minimo y maximo

            Vector3 mov = new Vector3(directionCurrentVelocity.x, rb.linearVelocity.y, directionCurrentVelocity.y);
            rb.linearVelocity = mov;
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            directionCurrentVelocity = Vector2.zero;
            transform.position = checkPoint.position;
            /*transform.DOScale(scaleStart, timeDuration).SetEase(curve);
            transform.DOScale(scaleEnd, timeDuration);*/
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Limit"))
        {
            OnMovement = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.Score++;
            Destroy(other.gameObject);
        }
    }
    #endregion

    #region PlayerInputAction
    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        if (context.performed)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void ChangeShapeNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    public void ChangeShapePrev(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
    }
    public void OffPlayerMovement()
    {

    }
    #endregion
}

