using UnityEngine;

namespace Enemy
{
    public class StunState : IEnemyState
    {
        private float _timer = 0;

        public StunState()
        {
            enemyState = EnemyStates.Stun;
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