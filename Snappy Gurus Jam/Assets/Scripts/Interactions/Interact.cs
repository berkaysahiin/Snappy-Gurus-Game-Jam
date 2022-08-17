using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SB
{
    public class Interact : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        private InputActionMap _inputActionMap;
        private InputAction _interactAction;
    
        public bool InteractButton { get; private set;}

        private void Awake()
        {
            _inputActionMap = playerInput.currentActionMap;
            _interactAction = _inputActionMap.FindAction("Interact");
            _interactAction.performed += OnInteract;
            _interactAction.canceled += OnInteract;
        }

        private void Update()
        {
            Debug.Log(InteractButton);

        }

        private void OnInteract(InputAction.CallbackContext callbackContext)
        {
            InteractButton = callbackContext.ReadValue<bool>();
            if (callbackContext.performed)
            {
                Debug.Log("GIRDIM");
            }
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