using System;
using System.Numerics;
using SB;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraRoot;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float upperLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float mouseSensitivity;

    private Rigidbody _rigidbody;
    private float _xRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveCamera(InputManager _inputManager)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        var Mouse_X = _inputManager.Look.x;
        var Mouse_Y = _inputManager.Look.y;
        mainCamera.position = cameraRoot.position;
            
            
        _xRotation -= Mouse_Y * mouseSensitivity * Time.smoothDeltaTime;
        _xRotation = Mathf.Clamp(_xRotation, upperLimit, bottomLimit);

        mainCamera.localRotation = Quaternion.Euler(_xRotation, 0 , 0);
        //_rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0, Mouse_X * mouseSensitivity * Time.smoothDeltaTime, 0));
        transform.Rotate(Vector3.up * _inputManager.Look.x);
    }
   
   
}