using UnityEngine;

public class DoublyLinkedCircularList
{
    public NodeShape head;

    public void Add(Mesh Shape)
    {
        NodeShape newShape = new NodeShape(Shape);

        if (head == null)
        {
            head = newShape;

            return;
        }

        NodeShape lastShape = head.prev;

        lastShape.next = newShape;
        newShape.prev = lastShape;
        newShape.next = head;
        head.prev = newShape;

    }
    public NodeShape GetHead()
    {
        return head;
    }
}
