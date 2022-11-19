namespace Enemy
{
    public class AttackState : IEnemyState
    {
        public EnemyStates name = EnemyStates.Attack;
        public void Invoke(EnemyControler currentEnemy)
        {
            currentEnemy.GetAttackType().Attack();
        }
    }
}