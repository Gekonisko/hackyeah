using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Enemy
{
    public class EnemyControler : MonoBehaviour, IProvocable
    {
        public float damage;
        public float attacksSpeed;
        public float attackRange;
        public float hp;
        public float movementSpeed;
        public float stunTime;

        public Transform playerPosition;
        
        private IAttackType _currentAttack;
        public EnemyStateManager stateManager;
        private Rigidbody _rigidbody;

        public void Start()
        { 
            _currentAttack = GetComponent<IAttackType>();
            stateManager = new EnemyStateManager(new List<IEnemyState>(GetComponents<IEnemyState>()));
            _rigidbody = GetComponent<Rigidbody>();
        }

        public IAttackType GetAttackType()
        {
            return _currentAttack;
        }

        public void GoToDirection(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 40.0f);
            }
            _rigidbody.AddForce(direction.normalized * movementSpeed * Time.deltaTime);
        }

        public void Provoke(Transform target)
        {
            throw new System.NotImplementedException();
        }
    }
}