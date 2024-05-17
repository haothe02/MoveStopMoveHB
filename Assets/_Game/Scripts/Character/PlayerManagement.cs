using Lean.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManagement : CharacterManagement
{
    [SerializeField] private CameraController _cam;
    [SerializeField] private VariableJoystick _joystick;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    
    private Vector3 _camScale = new Vector3(0, 1, -1);
    private bool _canMove;

    private void Awake()
    {
        _canMove = true;
    }
    private void Update()
    {
        CheckRange();
        CheckLevel();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (_canMove) {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _movementSpeed, _rigidbody.velocity.y, _joystick.Vertical * _movementSpeed);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                ChangeAnim(Constant.Anim.ANIM_RUN);
            }
            else if (_rigidbody.velocity == Vector3.zero)
            {
                ChangeAnim(Constant.Anim.ANIM_IDLE);
            }
        }
        
    }
    private void CheckRange()
    {
        if (_enemyInRange && Input.GetMouseButtonUp(0) && _listTarget.Count > 0)
        {
            Shoot();
        }
    }
    private void CheckLevel()
    {
        if(_levelUp)
        {
            _cam.CameraScaleUp(_camScale);
            _levelUp = false;
        }
    }
}
