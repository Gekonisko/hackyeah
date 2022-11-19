using UnityEngine;

namespace Enemy.States
{
    public class StandByState : IEnemyState
    {
        private float _timer = 0;
        public StandByState()
        {
            enemyState = EnemyStates.Standby;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            if (_timer > currentEnemy.stunTime)
            {
                currentEnemy.stateManager.SetState(EnemyStates.Standby);
                _timer = 0;
                return;
            }

            _timer += Time.deltaTime;
        }
    }
}