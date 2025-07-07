using UnityEngine;

public class NodeShape
{
    #region Properties
    public Mesh currentShapeMesh;
    public NodeShape next;
    public NodeShape prev;
    #endregion

    #region Constructor
    public NodeShape(Mesh shape)
    {
        this.currentShapeMesh = shape;
        this.next = this;
        this.prev = this;
    }
    #endregion
}
