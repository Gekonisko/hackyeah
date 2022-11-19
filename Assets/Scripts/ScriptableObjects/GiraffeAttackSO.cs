using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiraffeAttack", menuName = "ScriptableObjects/GiraffeAttack", order = 1)]
public class GiraffeAttackSO : ScriptableObject {
    public AttackType type;
    public float damage;
    public float radius;
}
