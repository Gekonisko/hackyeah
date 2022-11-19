namespace Enemy
{
    public interface IEnemyState
    {
        public void Invoke(EnemyControler currentEnemy);
    }
}