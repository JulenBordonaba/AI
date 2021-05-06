using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AI.Pathfinding
{

    [System.Serializable]
    [SerializeField]
    public class PathfindingNode : IConvertible
    {
        #region fields

        private NodeState state = NodeState.Untested;

        private float weight;

        private bool isDestination;

        private HeuristicType heuristicType;

        [SerializeField]
        private PathfindingNode destination;

        [SerializeField]
        private PathfindingNode parent;

        [SerializeField]
        private Vector3 position;

        private List<PathfindingNode> connections = new List<PathfindingNode>();

        private bool isStatic;

        private float manhattaDistanceToDestination;

        private float euclideanDistanceToDestination;

        private float distanceToParent;

        protected string id;

        private Dictionary<PathfindingNode, PathfindingConnection> connectionDictionary = new Dictionary<PathfindingNode, PathfindingConnection>();

        #endregion

        #region Methods

        public void UpdateDistances()
        {
            manhattaDistanceToDestination = position.ManhattaDistance(destination.position);
            euclideanDistanceToDestination = Vector3.Distance(position, destination.position);
        }

        public void Reset(NodeResetMode resetMode)
        {
            switch (resetMode)
            {
                case NodeResetMode.complete:
                    weight = 0;
                    destination = null;
                    isDestination = false;
                    connections.Clear();
                    break;
                case NodeResetMode.conections:
                    connections.Clear();
                    break;
                case NodeResetMode.configuration:
                    weight = 0;
                    destination = null;
                    isDestination = false;
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            string toString = "";

            //toString = string.Format("Position {0} /// Parent {1}", position, parent);
            toString = string.Format("Name {0}, Position {1} ",id, position);

            return toString;
        }

        #region IConvertible

        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            return F;
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Properties

        public string Id
        {
            get => id;
        }

        public bool IsStatic
        {
            get
            {
                return isStatic;
            }
            set
            {
                bool aux = isStatic;
                isStatic = value;

                if (isStatic && !aux)
                {
                    UpdateDistances();
                }
            }
        }

        public List<PathfindingNode> Connections
        {
            get
            {
                return connections;
            }
            set
            {
                connections = value;
            }
        }

        public PathfindingNode Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
                weight = parent.weight + Vector3.Distance(position, parent.position);
            }
        }

        public bool ConnectedToDestination
        {
            get
            {
                return connections.Contains(destination);
            }
        }

        public Vector3 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public PathfindingNode Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        public NodeState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public bool IsDestination
        {
            get
            {
                return isDestination;
            }
            set
            {
                isDestination = value;
            }
        }

        public HeuristicType HeuristicType
        {
            get
            {
                return heuristicType;
            }
            set
            {
                heuristicType = value;
            }
        }

        public float Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public float Heuristic
        {
            get
            {
                float returnValue = 0;
                switch (heuristicType)
                {
                    case HeuristicType.euclidean:
                        returnValue = EuclideanDistanceToDestination;
                        break;
                    case HeuristicType.manhattan:
                        returnValue = ManhattanDistanceToDestination;
                        break;
                    default:
                        Debug.LogError("Heuristic type not implemented");
                        break;
                }

                return returnValue;
            }
        }

        public float ManhattanDistanceToDestination
        {
            get
            {
                if (isStatic) return manhattaDistanceToDestination;
                return position.ManhattaDistance(destination.position);
            }
        }

        public float EuclideanDistanceToDestination
        {
            get
            {
                if (isStatic) return euclideanDistanceToDestination;

                if (position == null) Debug.Log("Position = null");
                if (destination == null) Debug.Log("destination = null");
                else if (destination.position == null) Debug.Log("destination.position = null");

                return Vector3.Distance(position, destination.position);
            }
        }

        public float F
        {
            get
            {
                return Weight + Heuristic;
            }
        }

        public Dictionary<PathfindingNode, PathfindingConnection> ConnectionDictionary
        {
            get
            {
                return connectionDictionary;
            }
            set
            {
                connectionDictionary = value;
            }
        }

        #endregion
    }
}
