using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [Header("Skewers")]
    [SerializeField] private bool OnBehaverSkewers = false;
    [Range(0.1f, 1)] private float MovDistance = 0.5f;

    [Header("Baci")]
    [SerializeField] private float thrustForce;
    [SerializeField] private float explosionRadius = 5f;

    private Vector3 savePosition;
    void Start()
    {
        savePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();
            PushPlayer(player);
        }
    }
    public void PushPlayer(Rigidbody player)
    {
        player.AddExplosionForce(thrustForce * 100, transform.position, explosionRadius);
    }
}
