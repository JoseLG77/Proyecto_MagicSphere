using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private float thrustForce;
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private Vector3 RotationVelocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotationObject();
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
    public void RotationObject()
    {
        Quaternion rotationPlanet = Quaternion.Euler(RotationVelocity * Time.deltaTime);
        transform.rotation = transform.rotation * rotationPlanet;
    }
}
