using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Pathfinding;

public class TestNode : PathfindingNode
{
    public VertexView view;

    public TestNode(VertexView _vertexView)
    {
        view = _vertexView;
        view.testNode = this;
        Position = view.transform.position;
        id = IDManager.CreateID("TestNode", 4);
        view.gameObject.name = id;
    }
    
    public static TestNode StartNode
    {
        get
        {
            return VertexView.startVertex.testNode;
        }
    }
    public static TestNode DestinationNode
    {
        get
        {
            return VertexView.destinationVertex.testNode;
        }
    }
}
