using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour, IDamageable {
    [SerializeField] private float health;

    // Update is called once per frame
    public void TakeDamage(float damage){
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }
}
