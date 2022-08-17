using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using SB;
using TMPro;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovementController : MonoBehaviour
{
   [SerializeField] private Transform orientation;
   [SerializeField] private float playerHeight;
   [SerializeField] private float groundDrag;
   [SerializeField] private LayerMask groundLayerMask;
   
   private PlayerAnimationController _playerAnimationController;
   
   private Rigidbody _rigidbody;
   private InputManager _inputManager;
   private Vector2 _currentVelocity;
   private Vector3 _moveDir;

   private float _speedCoefficient; 
   private bool _grounded;

   private const float WalkSpeed = 4f;
   private const float RunSpeed = 6;

   private void Start()
   {
      _playerAnimationController = GetComponent<PlayerAnimationController>();
      _rigidbody = GetComponent<Rigidbody>();
      _inputManager = GetComponent<InputManager>();

      _rigidbody.freezeRotation = true;
   }

   private void Update()
   {
      _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayerMask);
      
      _playerAnimationController.Animate(_currentVelocity);
      SpeedController();
      
      _rigidbody.drag = _grounded ? groundDrag : 0.0f;
   }

   private void FixedUpdate()
   {
      Move();
   }
   
   private void Move()
   {
      _speedCoefficient = _inputManager.Run ? RunSpeed : WalkSpeed;
      if (_inputManager.Move == Vector2.zero) _speedCoefficient = 0.1f; 
      
      _moveDir = (orientation.forward * _inputManager.Move.y + orientation.right * _inputManager.Move.x);
      _rigidbody.AddForce(_moveDir.normalized * _speedCoefficient , ForceMode.VelocityChange);
   }

   private void SpeedController()
   {
      var rbVel = _rigidbody.velocity;
      
      var flatVel = new Vector3(rbVel.x, 0f, rbVel.z);

      if (flatVel.magnitude > _speedCoefficient)
      {
         var limitedVel = flatVel.normalized * _speedCoefficient;
         _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
      }
   }
}