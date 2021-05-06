using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioSystem;
using AI;

[System.Serializable]
[SerializeField]
public class EnemyPatrol : EnemyState
{
    [SerializeField]
    private CollectionIndex<Transform> currentPoint;

    public EnemyPatrol(EnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override IEnumerator End()
    {
        enemyStateMachine.AgentListener.OnSoundRecieved -= OnSoundReceived;
        yield break;
    }

    public override IEnumerator Start()
    {
        currentPoint = new CollectionIndex<Transform>(enemyStateMachine.wayPoints);

        enemyStateMachine.Agent.SetDestination(CurrentWayPoint);
        enemyStateMachine.AgentListener.OnSoundRecieved += OnSoundReceived;
        currentPoint = new CollectionIndex<Transform>(WayPoints);
        yield break;
    }

    public override void Update()
    {
        
        if (ReachedNextPoint)
        {
            Debug.Log("update");
            currentPoint += 1;
            enemyStateMachine.Agent.SetDestination(CurrentWayPoint);
        }

        

        if(IsEnemyVisible)
        {
            enemyStateMachine.SetState(new EnemyChase(enemyStateMachine, enemyStateMachine.AgentView.Target));
        }
    }

    private bool IsEnemyVisible
    {
        get
        {
            if (enemyStateMachine == null) return false;
            if (enemyStateMachine.AgentView == null) return false;
            if (enemyStateMachine.AgentView.visibleEntities == null) return false;
            if (enemyStateMachine.AgentView.visibleEntities.Count<=0) return false;
            return true;
        }
    }

    

    private void OnSoundReceived(SoundData data)
    {
        if (data == null)
        {
            Debug.Log("Data es null");
            return;
        }
        Debug.Log(data.power / Vector3.Distance(data.castPosition, enemyStateMachine.transform.position));
        if(data.power/Vector3.Distance(data.castPosition,enemyStateMachine.transform.position)>1)
        enemyStateMachine.SetState(new EnemyAlert(enemyStateMachine));
    }

    private List<Transform> WayPoints
    {
        get
        {
            return enemyStateMachine.wayPoints;
        }
    }

    private Vector3 CurrentWayPoint
    {
        get
        {
            return WayPoints[currentPoint].position;
        }
    }

    private Vector3 NextWayPoint
    {
        get
        {
            int nextPoint = new CollectionIndex<Transform>(WayPoints, currentPoint + 1);

            return WayPoints[nextPoint].position;
        }
    }

    private Vector3 PreviousWayPoint
    {
        get
        {
            int previousPoint = new CollectionIndex<Transform>(WayPoints,currentPoint-1);

            return WayPoints[previousPoint].position;
        }
    }

    private bool ReachedNextPoint
    {
        get
        {
            return Vector3.Distance(enemyStateMachine.Agent.destination, stateMachine.transform.position) < enemyStateMachine.Agent.stoppingDistance + 0.2f;
        }
    }
}
