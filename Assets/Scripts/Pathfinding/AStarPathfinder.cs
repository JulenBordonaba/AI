using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    [System.Serializable]
    [SerializeField]
    public class AStarPathfinder
    {
        public PathfindingNode GeneratePath(PathfindingNode start, PathfindingNode destination, PathfindingGraph graph, out bool pathExists)
        {
            graph.SetDestination(destination);
            graph.UpdateNodeDistances();

            PathfindingNode current = start;

            BinaryPile<PathfindingNode> openNodes = new BinaryPile<PathfindingNode>();
            BinaryPile<PathfindingNode> closedNodes = new BinaryPile<PathfindingNode>();
            
            current.Weight=0;

            do
            {
                foreach (PathfindingNode node in current.Connections)
                {
                    float dist = Vector3.Distance(current.Position, node.Position);
                    if(openNodes.Contains(node) || closedNodes.Contains(node))
                    {
                        if (node.Weight > current.Weight + dist)
                        {
                            node.Parent = current;
                        }
                    }
                    else
                    {
                        node.Parent = current;
                        
                        openNodes.Add(node);
                    }

                    


                }
                closedNodes.Add(current);

                current = openNodes.TakeFirst();

                if (current.IsDestination)
                {
                    pathExists = true;
                    return current;
                }
            } while (openNodes.Count > 0);

            pathExists = false;
            return closedNodes.FirstElement;

        }
    }
}