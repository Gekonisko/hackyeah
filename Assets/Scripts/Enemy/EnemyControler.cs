using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy {
    public class EnemyControler : MonoBehaviour, IProvocable, IDamageable {
        public float damage;
        public float attackSpeed;
        public float attackRange;
        public float hp;
        public float movementSpeed;
        public float torque;
        public float stunTime;

        public Transform playerPosition;

        private IAttackType _currentAttack;
        public Animator animator;
        public EnemyStateManager stateManager;
        private Rigidbody _rigidbody;
        private bool _isPlayerInRange = false;

        public void Start() {
            _currentAttack = GetComponent<IAttackType>();
            stateManager = new EnemyStateManager(new List<IEnemyState>(GetComponents<IEnemyState>()));
            _rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            GetComponent<SphereCollider>().radius = attackRange;
        }

        private void Update() {
            stateManager.Invoke(this);
        }

        public IAttackType GetAttackType() {
            return _currentAttack;
        }

        public Vector3 DirectionToPlayer() {
            return (playerPosition.position - transform.position).normalized;
        }

        public Vector3 DirectionToPlayerPlusVelocity() {
            return ((playerPosition.position + _rigidbody.velocity) - transform.position).normalized;
        }

        public void DashToDirection(Vector3 direction, float strengthDash) {
            TurnToDirection(direction);
            _rigidbody.AddForce(direction * strengthDash, ForceMode.Impulse);
        }

        public void TurnToDirection(Vector3 direction) {
            if (playerPosition != null)
                transform.LookAt(playerPosition);
        }

        public void GoToDirection(Vector3 direction) {
            TurnToDirection(direction);

            var force = direction.normalized * movementSpeed * Time.deltaTime;
            _rigidbody.AddForce(force);
        }

        public void Provoke(Transform target) {
            if (!stateManager.IsProvoked()) {
                playerPosition = target;
                if (_isPlayerInRange) {
                    stateManager.SetState(EnemyStates.Attack);
                } else {
                    stateManager.SetState(EnemyStates.FollowPlayer);
                }
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                _isPlayerInRange = true;
                if (stateManager.IsProvokedAndNotStunnedAndNotDead()) {
                    stateManager.SetState(EnemyStates.Attack);
                }
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Player")) {
                _isPlayerInRange = false;
                if (stateManager.IsProvokedAndNotStunnedAndNotDead()) {
                    if (stateManager.didAttack) {
                        stateManager.SetState(EnemyStates.FollowPlayer);
                    } else {
                        stateManager.shouldLeftAttack = true;
                    }
                }
            }
        }

        public void TakeDamage(float damage) {
            hp -= damage;
            if (hp <= 0) {
                Die();
            }
        }

        public void Die() {
            stateManager.SetState(EnemyStates.Death);
        }

        private void OnCollisionEnter(Collision collision) {
            if (!Equals(collision.collider.GetComponent<IDamageable>(), null) && collision.collider.transform.CompareTag("Player")) {
                collision.collider.GetComponent<IDamageable>().TakeDamage(damage);
            }
        }
    }
}