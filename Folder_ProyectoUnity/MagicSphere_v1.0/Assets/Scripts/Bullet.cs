using UnityEngine;

public class Bullet : BaseObstacles
{
    [SerializeField] private float speed = 1.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Displazment();
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObstaclePush(collision, "Player");
    }
    private void Displazment()
    {
        rb.linearVelocity = Vector3.forward * speed;
    }
}
