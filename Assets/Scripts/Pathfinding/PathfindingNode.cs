using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathfindingNode : IConvertible
{
    #region fields

    private NodeState state = NodeState.Untested;

    private float weight;

    private bool isDestination;

    private HeuristicType heuristicType;

    private PathfindingNode destination;

    private PathfindingNode parent;

    private Vector3 position;

    private List<PathfindingNode> conections = new List<PathfindingNode>();

    private bool isStatic;

    private float manhattaDistanceToDestination;

    private float euclideanDistanceToDestination;

    #endregion

    #region Methods

    public void UpdateDistances()
    {
        manhattaDistanceToDestination = position.ManhattaDistance(destination.position);
        euclideanDistanceToDestination = Vector3.Distance(position, destination.position);
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

    public List<PathfindingNode> Conections
    {
        get
        {
            return conections;
        }
        set
        {
            conections = value;
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
        }
    }

    public bool ConnectedToDestination
    {
        get
        {
            return conections.Contains(destination);
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

    #endregion
}
