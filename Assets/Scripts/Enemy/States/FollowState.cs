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
            currentEnemy.GoToDirection(Vector3.Scale(currentEnemy.playerPosition.position - currentEnemy.transform.position, new Vector3(1,0,1)));
        }
    }
}