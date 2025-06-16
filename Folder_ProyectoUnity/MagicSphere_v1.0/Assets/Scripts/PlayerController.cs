using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Properties
    [Header("Statistics")]
    [SerializeField] private bool OnMovement;
    [SerializeField] private float velocityMax = 5; //Velocidad Final.
    [SerializeField] private float acceleration = 5; //Tiempo para que llegue a la velocidad final.
    [SerializeField] private float jumpForce;
    [Header("CheckPoint")]
    [SerializeField] private Transform checkPoint;

    private bool isJump;
    private bool isPressed;
    private Vector2 direction;
    private Vector2 directionVelocityMax;
    [SerializeField] private Vector2 directionCurrentVelocity;
    private Rigidbody rb;
    #endregion

    #region UnityMethods
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
        if (OnMovement)
        {
            if (!isPressed)
            {
                if (directionCurrentVelocity.magnitude > 0.1f)
                {
                    directionCurrentVelocity = Vector2.Lerp(directionCurrentVelocity, Vector2.zero, Time.deltaTime * acceleration * 0.25f);
                }
                else
                {
                    directionCurrentVelocity = Vector2.zero;
                }
                Vector3 desaleracion = new Vector3(directionCurrentVelocity.x, rb.linearVelocity.y, directionCurrentVelocity.y);
                rb.linearVelocity = desaleracion;
                return;
            }
            directionCurrentVelocity += direction * acceleration * Time.deltaTime;

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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            directionCurrentVelocity = Vector2.zero;
            transform.position = checkPoint.position;
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
    #endregion

    #region Methods
    private void ChangeShape()
    {

    }
    #endregion
}

