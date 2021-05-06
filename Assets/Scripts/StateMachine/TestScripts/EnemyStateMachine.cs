using AudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AI.StateMachine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ListeningArea))]
[RequireComponent(typeof(EnemyView))]
public class EnemyStateMachine : StateMachine
{
    public GameObject destination;
    public List<Transform> wayPoints = new List<Transform>();
    private NavMeshAgent agent;

    private ListeningArea agentListener;
    private EnemyView agentView;

    private void Awake()
    {
        SetState(new EnemyPatrol(this));
    }

    protected override void Update()
    {
        base.Update();
        destination.transform.position = agent.destination;
    }

    public ListeningArea AgentListener
    {
        get
        {
            if (agentListener == null) agentListener = GetComponent<ListeningArea>();
            return agentListener;
        }
        set
        {
            agentListener = value;
        }
    }

    public EnemyView AgentView
    {
        get
        {
            if (agentView == null) agentView = GetComponent<EnemyView>();
            return agentView;
        }
        set
        {
            agentView = value;
        }
    }

    public NavMeshAgent Agent
    {
        get
        {
            if (agent != null) return agent;
            if ((agent = GetComponent<NavMeshAgent>()) != null) return agent;
            return null;
        }
    }
}
