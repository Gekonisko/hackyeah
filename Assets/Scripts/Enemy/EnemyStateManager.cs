using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyStateManager
    {
        private readonly Dictionary<EnemyStates, IEnemyState> _states = new();
        private IEnemyState _currentState;

        public EnemyStateManager(List<IEnemyState> inputStates)
        {
            foreach (var state in inputStates)
            {
                _states.Add(state.enemyState, state);
            }
        }
        public void SetState(EnemyStates newState)
        {
            _currentState = _states[newState];
        }

        public IEnemyState GetCurrentState()
        {
            return _currentState;
        }

        public void Invoke(EnemyControler currentEnemy)
        {
            _currentState.Invoke(currentEnemy);
        }

        public bool IsStunned()
        {
            if (_currentState.enemyState == EnemyStates.Stun)
            {
                return true;
            }
            return false;
        }

        public bool IsProvoked()
        {
            if (_currentState.enemyState == EnemyStates.Standby)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsProvokedAndNotStunned()
        {
            return IsProvoked() && !IsStunned();
        }
    }
}