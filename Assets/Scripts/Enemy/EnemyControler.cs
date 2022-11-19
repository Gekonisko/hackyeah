using System.Collections.Generic;
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

        public Transform playerPosition;
        
        private IAttackType _currentAttack;
        private EnemyStateManager _stateManager;
        private Rigidbody _rigidbody;

        public void Start()
        { 
            _currentAttack = GetComponent<IAttackType>();
            _stateManager = new EnemyStateManager(new List<IEnemyState>(GetComponents<IEnemyState>()));
            _rigidbody = GetComponent<Rigidbody>();
        }

        public IAttackType GetAttackType()
        {
            return _currentAttack;
        }

        public void GoToDirection(Vector3 direction)
        {
            _rigidbody.AddForce(direction.normalized * movementSpeed);
        }
    }
}