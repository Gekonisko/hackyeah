namespace Enemy
{
    
    
    public class EscapeState : IEnemyState
    {
        public EscapeState()
        {
            enemyState = EnemyStates.Escape;
        }
        
        public override void Invoke(EnemyControler currentEnemy)
        {
            throw new System.NotImplementedException();
        }
    }
}