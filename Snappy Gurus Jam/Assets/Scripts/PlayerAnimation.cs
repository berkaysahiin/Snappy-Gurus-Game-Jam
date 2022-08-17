using System;
using UnityEngine;

public class PlayerAnimation: MonoBehaviour
{
    public Animator _animator { get; private set; }
    private PlayerController _playerController;
    
    private static readonly int XVelocity = Animator.StringToHash("X_Velocity");
    private static readonly int YVelocity = Animator.StringToHash("Y_Velocity");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _animator.SetFloat(XVelocity,_playerController._currentVelocity.x);
        _animator.SetFloat(YVelocity,_playerController._currentVelocity.y);
    }
}