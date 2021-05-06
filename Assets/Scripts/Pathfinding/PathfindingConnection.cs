using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    public class PathfindingConnection
    {
        public PathfindingNode node1;
        public PathfindingNode node2;

        public void ConnectNodes(PathfindingNode _node1, PathfindingNode _node2)
        {
            node1 = _node1;
            node2 = _node2;

            node1.Connections.Add(node2);
            node2.Connections.Add(node1);
        }

        public PathfindingNode Other(PathfindingNode _node)
        {
            if (node1 == _node) return node2;
            if (node2 == _node) return node1;

            throw new System.Exception("Node not found");
        }

        public bool Conatains(PathfindingNode _node1, PathfindingNode _node2)
        {
            if (_node1 == _node2) throw new System.Exception("Both nodes are the same");
            bool hasNode1 = _node1 == node1 || _node1 == node2;
            bool hasNode2 = _node2 == node1 || _node2 == node2;

            return hasNode1 && hasNode2;
        }
    }
}
