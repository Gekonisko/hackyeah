using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.States
{
    public class StandByState : IEnemyState
    {
        public float moveChances;
        public StandByState()
        {
            enemyState = EnemyStates.Standby;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            float roll = Random.Range(0f,1f);
            if (roll <= moveChances)
            {
                float x = Random.Range(-10, 10);
                float z = Random.Range(-10, 10);
                currentEnemy.GoToDirection(new Vector3(x,0,z));
            }
        }


    }
}