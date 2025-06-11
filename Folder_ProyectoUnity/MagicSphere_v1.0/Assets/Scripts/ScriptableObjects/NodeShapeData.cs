using UnityEngine;

[CreateAssetMenu(fileName = "New Shape Node", menuName = "DoublyLinkedCircularList/ ShapeNode")]
public class NodeShapeData : ScriptableObject
{
    public Mesh beforeShape;
    public Mesh nowShape;
    public Mesh afterShape;
}
