using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using SB;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovementController : MonoBehaviour
{
   [SerializeField]private float speedInterpolationConstant;
   
   private PlayerAnimationController _playerAnimationController;
   private PlayerCameraController _playerCameraController;
   
   private Rigidbody _rigidbody;
   private InputManager _inputManager;
   private Vector2 _currentVelocity;

   private const float _walkSpeed = 2;
   private const float _runSpeed = 6;
  

   private void Start()
   {
      _playerCameraController = GetComponent<PlayerCameraController>();
      _playerAnimationController = GetComponent<PlayerAnimationController>();
      _rigidbody = GetComponent<Rigidbody>();
      _inputManager = GetComponent<InputManager>();
   }

   private void Update()
   {
      _playerAnimationController.Animate(_currentVelocity);
   }

   private void FixedUpdate()
   {
      Move();
   }

   private void LateUpdate()
   {
      _playerCameraController.MoveCamera(_inputManager);
   }

   private void Move()
   {
      float speedCoefficient = _inputManager.Run ? _runSpeed : _walkSpeed;
      if (_inputManager.Move == Vector2.zero) speedCoefficient = 0.1f; // barely 0
      
      _currentVelocity = new Vector2
      (Mathf.Lerp
         (_currentVelocity.x, _inputManager.Move.x * speedCoefficient, speedInterpolationConstant * Time.fixedDeltaTime)
         , Mathf.Lerp
            (_currentVelocity.y, _inputManager.Move.y * speedCoefficient, speedInterpolationConstant * Time.fixedDeltaTime));
      
      var velocityDifference = _currentVelocity.ToVector3() - _rigidbody.velocity;
      _rigidbody.AddForce(transform.TransformVector(velocityDifference), ForceMode.VelocityChange);
   }
}