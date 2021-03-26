using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : EnemyState
{
    float count = 0;

    public EnemyAlert(EnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override IEnumerator End()
    {
        yield break;
    }

    public override IEnumerator Start()
    {

        count = 0;
        yield break;
    }



    public override void Update()
    {
        if (IsEnemyVisible)
        {
            enemyStateMachine.SetState(new EnemyChase(enemyStateMachine, enemyStateMachine.AgentView.Target));
        }
        count += Time.deltaTime;
        if(count>2)
        {
            enemyStateMachine.SetState(new EnemyPatrol(enemyStateMachine));
        }
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    private bool IsEnemyVisible
    {
        get
        {
            if (enemyStateMachine == null) return false;
            if (enemyStateMachine.AgentView == null) return false;
            if (enemyStateMachine.AgentView.visibleEntities == null) return false;
            if (enemyStateMachine.AgentView.visibleEntities.Count <= 0) return false;
            return true;
        }
    }

}
