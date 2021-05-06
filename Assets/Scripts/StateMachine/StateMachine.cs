using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        protected State currentState;

        public void SetState(State state)
        {
            if (currentState != null)
            {
                StartCoroutine(currentState.End());
            }
            currentState = state;
            StartCoroutine(currentState.Start());
        }

        protected virtual void Update()
        {
            currentState.Update();
        }
    }
}