using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Enemy
{
    public class EnemyStateManager
    {
        private readonly Dictionary<EnemyStates, IEnemyState> _states = new();

        public EnemyStateManager(List<IEnemyState> inputStates)
        {
            foreach (var state in inputStates)
            {
                _states.Add(state.enemyState, state);
            }
        }
    }
}