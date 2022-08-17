using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace SB
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 Move { get; private set; }
        public Vector2 Look { get; private set; }
        public bool Run { get; private set; }
        public bool InteractButton { get; private set; }

        [SerializeField] private PlayerInput playerInput;
        
        private InputActionMap _inputActionMap;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _runAction;
        private InputAction _interactAction;

        private void Awake()
        {
            _inputActionMap = playerInput.currentActionMap;
            _moveAction = _inputActionMap.FindAction("Move");
            _lookAction = _inputActionMap.FindAction("Look");
            _runAction = _inputActionMap.FindAction("Run");
            _interactAction = _inputActionMap.FindAction("Interact");

            _moveAction.performed += OnMove;
            _lookAction.performed += OnLook;
            _runAction.performed += OnRun;

            _moveAction.canceled += OnMove;
            _lookAction.canceled += OnLook;
            _runAction.canceled += OnRun;

            _interactAction.performed += OnInteract;
            _interactAction.canceled += OnInteract;
        }

        private void OnMove(InputAction.CallbackContext callbackContext)
        {
            Move = callbackContext.ReadValue<Vector2>();
        }

        private void OnLook(InputAction.CallbackContext callbackContext)
        {
            Look = callbackContext.ReadValue<Vector2>();
        }

        private void OnRun(InputAction.CallbackContext callbackContext)
        {
            Run = callbackContext.ReadValueAsButton();
        }

        private void OnInteract(InputAction.CallbackContext callbackContext)
        {
            InteractButton = callbackContext.ReadValueAsButton();
        }

        private void OnEnable()
        {
            _inputActionMap.Enable();
        }

        private void OnDisable()
        {
            _inputActionMap.Disable();
        }
    }
}