using UnityEngine;

public class Canon : BaseObstacles
{
    [Header("Behaviour")]
    [SerializeField] private float cadence;
    [SerializeField] private GameObject Bullet;

    [Header("AudioSFX")]
    [SerializeField] private AudioClip ShootSFX;

    private float currentTime;
    void Start()
    {
        AudioSFX = ShootSFX;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= cadence)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            currentTime = 0;
        }
    }
}
