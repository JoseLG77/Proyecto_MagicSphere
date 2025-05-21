using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private float thrustForce;
    [SerializeField] private float explosionRadius = 5f;

    void Start()
    {

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
