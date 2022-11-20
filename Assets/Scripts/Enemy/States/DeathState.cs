namespace Enemy.States
{
    public class DeathState : IEnemyState
    {
        public override void Invoke(EnemyControler currentEnemy)
        {
            currentEnemy.animator.SetBool("isRunning", false);
            currentEnemy.animator.SetBool("isWalking", false);
            currentEnemy.animator.SetBool("isDead", true);
            currentEnemy.animator.SetBool("isAttacking", false);
        }
    }
}