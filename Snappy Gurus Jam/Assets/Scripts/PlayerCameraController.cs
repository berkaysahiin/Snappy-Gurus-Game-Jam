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

    private InputManager _inputManager;

    private float _xRotation;
    private float _xRot;
    private float _yRot;

    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
    }

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
        var mouseX = _inputManager.Look.x;
        var mouseY = _inputManager.Look.y;
        mainCamera.position = cameraRoot.position;

        _yRot += mouseX;
        _xRot -= mouseY;

        _xRot = Mathf.Clamp(_xRot, -90f, 90f);
        transform.rotation = Quaternion.Euler(_xRot, _yRot, 0);
        orientation.rotation = Quaternion.Euler(0, _yRot, 0);
    }
}