using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing;

    private Vector3 _offset;

    private void Start(){
        _offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        Vector3 targetCamPos = target.position - _offset;
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
