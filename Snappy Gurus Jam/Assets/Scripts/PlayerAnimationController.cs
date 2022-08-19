using System;
using UnityEngine;

public class PlayerAnimationController: MonoBehaviour
{
    [HideInInspector] public Vector2 Velocity;
    public Animator Animator { get; private set; }
    
    private static readonly int XVelocity = Animator.StringToHash("X_Velocity");
    private static readonly int YVelocity = Animator.StringToHash("Y_Velocity");

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animator.SetFloat(XVelocity,Velocity.x);
        Animator.SetFloat(YVelocity,Velocity.y);
    }

    public void Animate(Vector2 v2)
    {
        Velocity = v2;
    }
}