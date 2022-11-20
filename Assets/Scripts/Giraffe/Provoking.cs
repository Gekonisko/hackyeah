using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provoking : MonoBehaviour
{
    [SerializeField] private float timeBetweenProvocations;
    [SerializeField] private float provokingRadius;

    [SerializeField] private Dialogs dialogs;
    
    private float _lastProvocationTime;
    void Start()
    {
        _lastProvocationTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || true) {
            if (Time.time - _lastProvocationTime > timeBetweenProvocations) {
                _lastProvocationTime = Time.time;
                Collider[] colliders = Physics.OverlapSphere(transform.position, provokingRadius);
                foreach (var collider in colliders) {
                    collider.GetComponent<IProvocable>()?.Provoke(transform);
                }
                dialogs.OnAction(DialogType.Provocation);
            }
        }
    }
}
