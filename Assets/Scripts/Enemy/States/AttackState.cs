namespace Enemy
{
    public class AttackState : IEnemyState
    {
        public AttackState()
        {
            enemyState = EnemyStates.Attack;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            currentEnemy.GetAttackType().Attack();
        }
    }
}