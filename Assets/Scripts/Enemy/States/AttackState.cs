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
            if (_timer == 0)
            {
                currentEnemy.GetAttackType().Attack(currentEnemy);
                currentEnemy.animator.SetBool("isRunning", false);
                currentEnemy.animator.SetBool("isWalking", false);
                currentEnemy.animator.SetBool("isDead", false);
                currentEnemy.animator.SetBool("isAttacking", true);
            }
            
            _timer += Time.deltaTime;
            
            if (_timer > currentEnemy.attackSpeed)
            {
                _timer = 0;
            }
        }
    }
}