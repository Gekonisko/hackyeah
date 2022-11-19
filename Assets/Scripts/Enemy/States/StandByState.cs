using System;
using UnityEngine;

namespace Enemy.States
{
    public class StandByState : IEnemyState
    {
        public StandByState()
        {
            enemyState = EnemyStates.Standby;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            
        }


    }
}