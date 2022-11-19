namespace Enemy
{
    public class StunState : IEnemyState
    {
        public StunState()
        {
            enemyState = EnemyStates.Stun;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            
        }
    }
}