using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    public Vector2 Move { get; private set;}
    public Vector2 Look { get; private set;}
    public bool Run { get; private set;}

    [SerializeField] private PlayerInput playerInput;

    private InputActionMap _InputActionMap;
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _runAction;

    private void Awake()
    {
        _InputActionMap = playerInput.currentActionMap;
        _moveAction = _InputActionMap.FindAction("Move");
        _lookAction = _InputActionMap.FindAction("Look");
        _runAction = _InputActionMap.FindAction("Run");

        _moveAction.performed += OnMove;
        _lookAction.performed += OnLook;
        _runAction.performed += OnRun;
        
        _moveAction.canceled += OnMove;
        _lookAction.canceled += OnLook;
        _runAction.canceled += OnRun;
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

    private void OnEnable()
    {
        _InputActionMap.Enable();
    }

    private void OnDisable()
    {
        _InputActionMap.Disable();
    }
}
