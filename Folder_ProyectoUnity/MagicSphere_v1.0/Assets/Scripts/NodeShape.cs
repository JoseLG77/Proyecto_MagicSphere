using UnityEngine;

public class NodeShape
{
    public GameObject currentShape;
    public NodeShape next;
    public NodeShape prev;

    public NodeShape(GameObject shape)
    {
        currentShape = shape;
    }
    public void SetNext(NodeShape node)
    {
        this.next = node;
    }
    public void SetPrev(NodeShape node)
    {
        this.prev = node;
    }
}
