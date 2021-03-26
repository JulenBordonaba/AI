using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public class EnemyState : State
{
    private EnemyStateMachine _enemyStateMachine;

    public EnemyState(StateMachine _stateMachine) : base(_stateMachine)
    {
        if(_stateMachine.GetType()==typeof(EnemyStateMachine))
        {
            _enemyStateMachine = (EnemyStateMachine)_stateMachine;
        }
    }

    protected EnemyStateMachine enemyStateMachine
    {
        get
        {
            return stateMachine as EnemyStateMachine;
        }
        set
        {
            stateMachine = value;
        }
    }

    protected override StateMachine stateMachine { get => _enemyStateMachine; set => _enemyStateMachine=value as EnemyStateMachine; }

    public override IEnumerator End()
    {
        yield return null;
    }

    public override IEnumerator Start()
    {
        yield return null;
    }

    public Transform transform
    {
        get
        {
            return enemyStateMachine.transform;
        }
    }
}
