using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    GoldenFish,
    Box,
    Monitor
}

public class Pickable : MonoBehaviour
{
    public ItemType ItemType { get; private set; }
    public float AllowDistance;
    public bool IsBeingHold { get; set; }
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var velocity = _rigidbody.velocity;
        _rigidbody.velocity = IsBeingHold ? new Vector3(velocity.x,0.1f,velocity.z) : _rigidbody.velocity;
    }
}
