namespace Enemy
{
    public class StandByState : IEnemyState
    {
        public StandByState()
        {
            enemyState = EnemyStates.Standby;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            throw new System.NotImplementedException();
        }
    }
}