using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Pathfinding;

public class TestGraph : PathfindingGraph
{
    private List<TestNode> testNodes;
    private List<ConnectionView> connectionViews;
    private Dictionary<Vector3, TestNode> nodePositions = new Dictionary<Vector3, TestNode>();

    public TestGraph(List<TestNode> _nodes, List<ConnectionView> _connections)
    {
        testNodes = _nodes;
        connectionViews = _connections;
    }

    public void ResetView()
    {
        foreach(PathfindingConnection c in connections)
        {
            TestConnection aux = (TestConnection)c;
            aux.isPath.Value = false;
        }
        foreach(TestNode t in testNodes)
        {
            if(t!=TestNode.StartNode && t!= TestNode.DestinationNode)
            {
                t.view.material = t.view.defaultMaterial;
            }
        }
    }

    public override void GenerateGraphConections()
    {

        //Debug.Log("Num nodos: " + testNodes.Count);



        nodePositions = new Dictionary<Vector3, TestNode>();
        foreach(TestNode node in testNodes)
        {
            if(!nodePositions.ContainsKey(node.Position))
            {
                nodePositions.Add(node.Position, node);
            }
            nodes.Add(node);
        }



        connections = new List<PathfindingConnection>();
        foreach (ConnectionView conn in connectionViews)
        {
            TestConnection testConnection = new TestConnection(conn.lineRenderer, false, Color.white, Color.green);

            TestNode node1 = nodePositions[conn.startPosition];
            TestNode node2 = nodePositions[conn.endPosition];

            if(!node1.ConnectionDictionary.ContainsKey(node2))
            {
                node1.ConnectionDictionary.Add(node2, testConnection);
            }
            if (!node2.ConnectionDictionary.ContainsKey(node1))
            {
                node2.ConnectionDictionary.Add(node1, testConnection);
            }

            testConnection.ConnectNodes(node1, node2);
            connections.Add(testConnection);
            testConnection.view = conn;
            
        }
    }
}
