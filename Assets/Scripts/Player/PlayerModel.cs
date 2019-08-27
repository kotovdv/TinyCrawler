using System;
using UnityEngine;

public class PlayerModel
{
    public const float Speed = 7.0F;
    public const float DashSpeed = 21.0F;
    public const float DashDurationSec = 0.125F;
    private readonly Rigidbody2D _rigidBody;

    public bool IsDashing = false;
    private bool _isRunning = false;
    private bool _isFacingRight = true;
    public Vector2 MovementDirection = Vector2.zero;

    public event Action<bool> OnIsRunningChanged;
    public event Action<bool> OnIsFacingRightChanged;

    public PlayerModel(Rigidbody2D rigidbody)
    {
        _rigidBody = rigidbody;
    }

    public bool IsRunning
    {
        get => _isRunning;
        set => HandleFieldChange(ref _isRunning, value, OnIsRunningChanged);
    }

    public bool IsFacingRight
    {
        get => _isFacingRight;
        set => HandleFieldChange(ref _isFacingRight, value, OnIsFacingRightChanged);
    }

    public Vector2 Velocity
    {
        get => _rigidBody.velocity;
        set => _rigidBody.velocity = value;
    }

    private static void HandleFieldChange<T>(ref T field, T newValue, Action<T> fieldEvent) where T : IEquatable<T>
    {
        var oldValue = field;
        if (Equals(oldValue, newValue)) return;

        field = newValue;
        fieldEvent?.Invoke(newValue);
    }
}