using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.StateMachine;

[RequireComponent(typeof(StateMachine))]
public class EnemyManager : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    private void Start()
    {
        
    }

}
