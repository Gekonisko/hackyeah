using UnityEngine;

namespace Enemy
{
    public abstract class IEnemyState : MonoBehaviour
    {
        public EnemyStates enemyState;
        public abstract void Invoke(EnemyControler currentEnemy);
    }
}