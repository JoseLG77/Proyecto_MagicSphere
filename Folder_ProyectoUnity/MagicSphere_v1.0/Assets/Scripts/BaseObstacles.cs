using UnityEngine;

public class BaseObstacles : MonoBehaviour
{
    [Header("Behavir Basic")]
    protected float thrustForce = 2;
    protected float explosionRadius = 5f;

    [Header("AudioSFX")]
    protected AudioClip AudioSFX;
    protected AudioSource source;
    //Metodo de empuje
    public void ObstaclePush(Collision collision, string targetTag)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(thrustForce * 100, transform.position, explosionRadius);
        }
        //Tiempo asintotico O(1)
    }
    //Metodo de activacion de sonido SFX para collisiones
    public void OnPlaySoundCollision(AudioSource audioSource, AudioClip AudioSFX)
    {
        if (audioSource == null || AudioSFX == null) return;
        audioSource.PlayOneShot(AudioSFX);
    }
}
