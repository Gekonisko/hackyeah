using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {
    Forward,
    Area
}

public class Fighting : MonoBehaviour, IDamageable {
    [SerializeField] private float health;

    [SerializeField] private Dialogs dialogs;
    
    [SerializeField] private Transform aoeAttackOriginPoint;
    [SerializeField] private Transform forwardAttackOriginPoint;

    [SerializeField] private GiraffeAttackSO[] jAttacks;
    [SerializeField] private GiraffeAttackSO[] kAttacks;
    [SerializeField] private GiraffeAttackSO[] lAttacks;


    private bool _canAttack;
    private GiraffeAttackSO _jAttack;
    private GiraffeAttackSO _kAttack;
    private GiraffeAttackSO _lAttack;

    private void Start(){
        _canAttack = true;
        
        //DEBUG?????
        _jAttack = jAttacks[0];
        _kAttack = kAttacks[0];
        _lAttack = lAttacks[0];
    }

    void Update(){
        if (_canAttack) {
            if (Input.GetKeyDown(KeyCode.J)) {
                // J attack
                Attack(_jAttack);
            }
            else if (Input.GetKeyDown(KeyCode.K)) {
                // K attack
                Attack(_kAttack);
            }
            else if (Input.GetKeyDown(KeyCode.L)) {
                // L attack
                Attack(_lAttack);
            }
        }
    }

    void Attack(GiraffeAttackSO attack){
        dialogs.OnAction(DialogType.Provocation);
        // Set what type of attack it is
        Transform origin;
        switch (attack.type) {
            case AttackType.Forward:
                origin = forwardAttackOriginPoint;
                break;
            case AttackType.Area:
                origin = aoeAttackOriginPoint;
                break;
            default:
                origin = aoeAttackOriginPoint;
                break;
        }
        
        // Get all affected entities
        Collider[] colliders = Physics.OverlapSphere(origin.position, attack.radius);
        foreach (var collider in colliders) {
            if (collider.gameObject == gameObject) {
                continue;
            }
            collider.GetComponent<IDamageable>()?.TakeDamage(attack.damage);
        }
    }

    public void EnableAttack(){
        _canAttack = true;
    }

    public void DisableAttack(){
        _canAttack = false;
    }

    public void SetJAttack(GiraffeAttackSO attack){
        _jAttack = attack;
    }
    
    public void SetKAttack(GiraffeAttackSO attack){
        _kAttack = attack;
    }
    
    public void SetLAttack(GiraffeAttackSO attack){
        _lAttack = attack;
    }

    IEnumerator EnableAttacks(float time){
        yield return new WaitForSecondsRealtime(time);
        EnableAttack();
    }

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
