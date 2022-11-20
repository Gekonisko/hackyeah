using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float directionFollowSpeed = 50f;
    
    private CharacterController _controller;

    private float _horizontalInputAxis;
    private float _verticalInputAxis;

    public bool _canPlayerMove;
    // Start is called before the first frame update
    void Start(){
        _controller = GetComponent<CharacterController>();
        _canPlayerMove = true;
    }

    // Update is called once per frame
    void Update(){
        _horizontalInputAxis = Input.GetAxis("Horizontal");
        _verticalInputAxis = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(_horizontalInputAxis, 0f, _verticalInputAxis);
        // Move player
        if (_canPlayerMove) {
            _controller.SimpleMove(movementSpeed * moveDirection);
        }

        // Rotate in moving direction
        if (moveDirection != Vector3.zero) {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (moveDirection), Time.deltaTime * directionFollowSpeed);
        }
    }
}
