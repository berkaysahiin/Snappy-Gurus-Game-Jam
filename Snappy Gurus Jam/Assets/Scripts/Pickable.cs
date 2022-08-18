using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
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
