using UnityEngine;

public class RotationObjectOstable : MonoBehaviour
{
    [SerializeField] private Vector3 RotationVelocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ro();
    }
    private void Ro()
    {
        Quaternion rotationPlanet = Quaternion.Euler(RotationVelocity * Time.deltaTime);
        transform.rotation = transform.rotation * rotationPlanet;
    }
}
