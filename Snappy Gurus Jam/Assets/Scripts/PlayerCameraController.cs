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
    [SerializeField] private Transform orientation;
    [SerializeField] private float sensitivity;
    
    [SerializeField] private float minClampVal;
    [SerializeField] private float maxClampVal;

    private float _xRotation;
    private float _xRot;
    private float _yRot;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        var mouseX = InputManager.Look.x;
        var mouseY = InputManager.Look.y;
        mainCamera.position = cameraRoot.position;

        _yRot += mouseX * sensitivity * Time.smoothDeltaTime;
        _xRot -= mouseY * sensitivity * Time.smoothDeltaTime;

        _xRot = Mathf.Clamp(_xRot, minClampVal, maxClampVal);
        transform.rotation = Quaternion.Euler(_xRot, _yRot, 0);
        orientation.rotation = Quaternion.Euler(0, _yRot, 0);
    }
}