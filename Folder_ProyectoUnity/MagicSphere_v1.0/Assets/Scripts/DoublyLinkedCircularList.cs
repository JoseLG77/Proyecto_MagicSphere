using UnityEngine;

public class DoublyLinkedCircularList
{
    public NodeShape head;

    public void Add(GameObject Shape)
    {
        NodeShape newShape = new NodeShape(Shape);

        if (head == null)
        {
            head = newShape;
            head.next = head;
            head.prev = head;
            return;
        }
        else
        {
            NodeShape lastShape = head.prev;
            lastShape.next = newShape;
            newShape.prev = lastShape;
            newShape.next = head;
            head.prev = newShape;
        }
    }
}
