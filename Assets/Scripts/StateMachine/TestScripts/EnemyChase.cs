using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    private Entity target;

    public EnemyChase(EnemyStateMachine _stateMachine, Entity _target) : base(_stateMachine)
    {
        target = _target;
    }

    public override IEnumerator End()
    {
        yield break;
    }

    public override IEnumerator Start()
    {
        yield break;
    }

    public override void Update()
    {
        if (enemyStateMachine.AgentView.Target != null)
        {
            enemyStateMachine.Agent.SetDestination(target.transform.position);
        }
        else
        {
            if(Vector3.Distance(enemyStateMachine.Agent.destination,enemyStateMachine.transform.position)<enemyStateMachine.Agent.stoppingDistance)
            {
                enemyStateMachine.SetState(new EnemyPatrol(enemyStateMachine));
            }
        }
    }
}
