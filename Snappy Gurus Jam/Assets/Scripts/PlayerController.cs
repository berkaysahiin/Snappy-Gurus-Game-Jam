using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using SB;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
   public Vector2 _currentVelocity { get; private set; }
   
   private Rigidbody _rigidbody;
   private InputManager _inputManager;
   
   private const float _walkSpeed = 2;
   private const float _runSpeed = 6;

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
      _inputManager = GetComponent<InputManager>();
   }

   private void Update()
   {
      Debug.Log(_inputManager.InteractButton);
   }

   private void FixedUpdate()
   {
      Move();
   }

   private void Move()
   {
      float speedCoefficient = _inputManager.Run ? _runSpeed : _walkSpeed;

      if (_inputManager.Move == Vector2.zero)
      {
         speedCoefficient = 0.1f; // barely 0
      }

      _currentVelocity = new Vector2(_inputManager.Move.x * speedCoefficient, _inputManager.Move.y * speedCoefficient);

      var velocityDifference = _currentVelocity.ToVector3() - _rigidbody.velocity;
      
      _rigidbody.AddForce(transform.TransformVector(velocityDifference), ForceMode.VelocityChange);
   }
}