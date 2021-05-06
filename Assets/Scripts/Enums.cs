using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    #region StateMachine

    public enum EnemyStates
    {
        patrol, alert, chase
    }

    #endregion

    #region Pathfinding

    public enum HeuristicType
    {
        euclidean, manhattan
    }

    public enum SortingOrder
    {
        ascendant, descendent
    }

    public enum NodeResetMode
    {
        conections, configuration, complete
    }

    /// <summary>
    /// Represents the search state of a Node
    /// </summary>
    public enum NodeState
    {
        /// <summary>
        /// The node has not yet been considered in any possible paths
        /// </summary>
        Untested,
        /// <summary>
        /// The node has been identified as a possible step in a path
        /// </summary>
        Open,
        /// <summary>
        /// The node has already been included in a path and will not be considered again
        /// </summary>
        Closed
    }

    #endregion
}