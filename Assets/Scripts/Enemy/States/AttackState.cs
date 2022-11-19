using UnityEngine;

namespace Enemy
{
    public class AttackState : IEnemyState
    {
        private float _timer = 0;
        public AttackState()
        {
            enemyState = EnemyStates.Attack;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer);
            if (_timer > currentEnemy.attackSpeed)
            {
                currentEnemy.GetAttackType().Attack(currentEnemy);
                _timer = 0;
            }
        }
    }
}