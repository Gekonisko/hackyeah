using System;
using System.Collections.Generic;
using Unity.VisualScripting;

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
    }
}