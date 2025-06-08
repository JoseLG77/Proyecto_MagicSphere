using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [Header("Skewers")]
    [SerializeField] private bool OnBehaverSkewers = false;
    [SerializeField] private float velocity = 1;
    [Range(0.1f, 2)] public float distance;

    [Header("Rotation")]
    [SerializeField] private bool OnBehavierRotation = false;
    [SerializeField] private Vector3 directionVecocity;

    [Header("Behavir Basic")]
    [SerializeField] private float thrustForce = 2;
    [SerializeField] private float explosionRadius = 5f;

    private Vector3 savePosition;
    private bool UpDown = true;
    void Start()
    {
        savePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RotationObject();
        Spikes();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();
            PushPlayer(player);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody player = collision.gameObject.GetComponent<Rigidbody>();
            Invoke("ResetVelocityObjectPush", 0.5f);
        }
    }
    public void PushPlayer(Rigidbody player)
    {
        player.AddExplosionForce(thrustForce * 100, transform.position, explosionRadius);
    }
    //Comportamiento de los ostaculos que rotan
    public void RotationObject()
    {
        if (!OnBehavierRotation) return;
        Quaternion rotation = Quaternion.Euler(directionVecocity * Time.deltaTime);
        transform.rotation *= rotation;
    }
    //Comportamiento de los pinchos
    public void Spikes()
    {
        if(!OnBehaverSkewers) return;

        float minY = savePosition.y;
        float maxY = savePosition.y + distance;

        if (UpDown)
        {
            transform.position += new Vector3(0, (velocity * 7) * Time.deltaTime, 0);

            if (transform.position.y >= maxY)
            {
                UpDown = false;
                Debug.Log("Arriba");
            }
        }
        else
        {
            transform.position -= new Vector3(0, velocity * Time.deltaTime, 0);
            if (transform.position.y <= minY)
            {
                UpDown = true;
            }
            Debug.Log("Abajo");
        }
    }
    private void ResetVelocityObjectPush(Rigidbody objectCollision)
    {
        objectCollision.linearVelocity = Vector3.zero;
    }
}
