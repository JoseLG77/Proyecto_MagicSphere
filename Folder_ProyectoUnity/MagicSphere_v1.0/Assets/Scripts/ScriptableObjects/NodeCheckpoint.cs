using UnityEngine;
[CreateAssetMenu(fileName = "CheckPoints", menuName = "Node", order = 1)]
public class NodeCheckpoint : ScriptableObject
{
    public string nameLevel;
    public Material[] materials;
}
