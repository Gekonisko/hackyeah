using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Enemy
{
    public class EnemyStateManager
    {
        private Dictionary<EnemyStates, IEnemyState> _states = new();

        public EnemyStateManager(List<IEnemyState> inputStates)
        {
            // _states.Add(EnemyStates.Attack, inputStates[0]);
            // _states.Add(EnemyStates.Standby);
            // _states.Add(EnemyStates.Attack, new AttackState());
            // _states.Add(EnemyStates.Attack, new AttackState());
            // _states.Add(EnemyStates.Attack, new AttackState());
        }
    }
}