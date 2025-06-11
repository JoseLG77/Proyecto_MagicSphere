using UnityEngine;

public class ObstacleRotation : BaseObstacles
{
    [Header("Behaviour")]
    [SerializeField] private Vector3 directionVecocity;

    [Header("AudioSFX")]
    [SerializeField] private AudioClip collisionSFX;

    void Start()
    {
        source = GetComponent<AudioSource>();
        AudioSFX = collisionSFX;
    }

    void Update()
    {
        RotationObject();
    }
    private void OnCollisionEnter(Collision collision)
    {
        ObstaclePush(collision, "Player");
        OnPlaySoundCollision(source, AudioSFX);
    }
    public void RotationObject()
    {
        Quaternion rotation = Quaternion.Euler(directionVecocity * Time.deltaTime);
        transform.rotation *= rotation;
    }
}
