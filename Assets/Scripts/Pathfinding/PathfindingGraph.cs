using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Pathfinding
{
    public abstract class PathfindingGraph
    {
        #region fields

        protected List<PathfindingNode> nodes = new List<PathfindingNode>();
        protected List<PathfindingConnection> connections = new List<PathfindingConnection>();

        #endregion

        #region Methods

        public void SetDestination(PathfindingNode destination)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Destination = destination;
                if (nodes[i] == destination)
                {
                    nodes[i].IsDestination = true;
                }
            }
        }

        public void Reset(NodeResetMode resetMode)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Reset(resetMode);
            }
        }
        
        public void UpdateNodeDistances()
        {
            foreach (PathfindingNode node in nodes)
            {
                node.UpdateDistances();
            }
        }

        public abstract void GenerateGraphConections();

        #endregion

        #region Properties

        public List<PathfindingNode> Nodes
        {
            get => nodes;
            set => nodes = value;
        }

        #endregion

    }
}