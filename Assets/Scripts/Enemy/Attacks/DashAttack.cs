using UnityEngine;

namespace Enemy
{
    public class DashAttack : MonoBehaviour, IAttackType
    {
        public int dashStrength;
        public void Attack(EnemyControler currentEnemy)
        {
            currentEnemy.DashToDirection(currentEnemy.DirectionToPlayer(), dashStrength);
        }
    }
}