using UnityEngine;

namespace Enemy
{
    public class EnemyControler : MonoBehaviour
    {
        public float damage;
        public float attacksSpeed;
        public float attackRange;
        public float hp;
        public float movementSpeed;
        public float stunTime;

        private Transform _playerPosition;
        
        private IAttackType _currentAttack;

        public void Start()
        {
            // var manager = new EnemyStateManager(GetComponents<IEnemyState>());
         _currentAttack = GetComponent<IAttackType>();
        }

        public IAttackType GetAttackType()
        {
            return _currentAttack;
        }
        
    }
}