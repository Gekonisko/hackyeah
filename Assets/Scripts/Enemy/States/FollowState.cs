using UnityEngine;

namespace Enemy
{
    public class FollowState : IEnemyState
    {
        public FollowState()
        {
            enemyState = EnemyStates.FollowPlayer;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentEnemy.playerPosition.position, currentEnemy.movementSpeed * Time.deltaTime);
        }
    }
}