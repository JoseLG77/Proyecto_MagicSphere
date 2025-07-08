using Unity.VisualScripting;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    #region Properties
    [Header("-----Node-----")]
    [SerializeField] private NodeCheckpoint checkpointData;
    [Header("-----Materials-----")]
    [SerializeField] private Material[] materials;
    [Header("-----bool-----")]
    [SerializeField] private bool isCheckpoint;

    private Renderer _render;
    #endregion

    #region Unity Methods
    void Start()
    {
        _render = GetComponent<Renderer>();
        materials = _render.materials;
        if (!isCheckpoint)
        {
            materials[2] = checkpointData.materials[1];
            _render.materials = materials;
        }
        else
        {
            materials[2] = checkpointData.materials[0];
            _render.materials = materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_render == null) return;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            materials[2] = checkpointData.materials[0];
            _render.materials = materials;
            if(other.GetComponent<PlayerController>() != null)
            {
                Vector3 position = transform.position;
                //position.y -= 2.5f;
                other.GetComponent<PlayerController>().CheckPoint.position = position;
            }
        }
    }
    #endregion
}
