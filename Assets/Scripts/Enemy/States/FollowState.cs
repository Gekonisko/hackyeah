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
            
        }
    }
}