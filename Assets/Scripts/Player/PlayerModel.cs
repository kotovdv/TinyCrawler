﻿using System;
using UnityEngine;

public class PlayerModel
{
    public const float Speed = 7.0F;
    public const float JumpSpeed = 21.0F;
    public const float JumpDurationSec = 0.125F;

    public readonly Rigidbody2D RigidBody;

    public Vector2 MovementDirection = Vector2.zero;
    public Vector2 AfterJumpMovementDirection = Vector2.zero;

    public bool IsJumping = false;
    private bool _isRunning = false;
    private bool _isFacingRight = true;

    public event Action<bool> OnIsRunningChanged;
    public event Action<bool> OnIsFacingRightChanged;

    public PlayerModel(Rigidbody2D rigidbody)
    {
        RigidBody = rigidbody;
    }

    public bool IsFacingRight
    {
        get => _isFacingRight;
        set => HandleFieldChange(ref _isFacingRight, value, OnIsFacingRightChanged);
    }

    public bool IsRunning
    {
        get => _isRunning;
        set => HandleFieldChange(ref _isRunning, value, OnIsRunningChanged);
    }

    private static void HandleFieldChange<T>(ref T field, T newValue, Action<T> fieldEvent) where T : IEquatable<T>
    {
        var oldValue = field;
        if (Equals(oldValue, newValue)) return;

        field = newValue;
        fieldEvent?.Invoke(newValue);
    }
}