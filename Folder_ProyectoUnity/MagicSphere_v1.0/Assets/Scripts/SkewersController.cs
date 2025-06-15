using UnityEngine;

public class SkewersController : BaseObstacles
{
    [Header("Behaviour")]
    [SerializeField] private float velocity = 1;
    [Range(0.1f, 2)] public float distance;

    [Header("AudioSFX")]
    [SerializeField] private AudioClip collisionSFX;

    private Vector3 savePosition;
    private bool UpDown = true;

    void Start()
    {
        savePosition = transform.position;
        source = GetComponent<AudioSource>();
        AudioSFX = collisionSFX;
    }

    void Update()
    {
        Spikes();
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObstaclePush(collision, "Player");
        OnPlaySoundCollision(source, AudioSFX);
    }
    public void Spikes()
    {
        float minY = savePosition.y;
        float maxY = savePosition.y + distance;

        if (UpDown)
        {
            transform.position += new Vector3(0, (velocity * 7) * Time.deltaTime, 0);

            if (transform.position.y >= maxY)
            {
                UpDown = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0, velocity * Time.deltaTime, 0);
            if (transform.position.y <= minY)
            {
                UpDown = true;
            }
        }
    }
}
