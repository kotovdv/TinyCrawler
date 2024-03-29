﻿using System;
using UnityEngine;

public class CharacterModel : ICharacterModel
{
    private readonly Rigidbody2D _rigidBody;

    private bool _isRunning;
    private bool _isFacingRight = true;

    public event Action<bool> OnIsRunningChanged;
    public event Action<bool> OnIsFacingRightChanged;

    public CharacterModel(
        Transform weaponGripPosition,
        Rigidbody2D rigidbody,
        IWeapon weapon)
    {
        _rigidBody = rigidbody;
        WeaponGripTransform = weaponGripPosition;
        Weapon = weapon;
    }

    public float Speed { get; } = 7.0F;

    public float DashSpeed { get; } = 21.0F;

    public float DashDurationSec { get; } = 0.125F;

    public bool IsDashing { get; set; } = false;

    public bool IsRunning
    {
        get => _isRunning;
        set => HandleFieldChange(ref _isRunning, value, OnIsRunningChanged);
    }

    public bool CanChangeFacing { get; set; } = true;

    public bool IsFacingRight
    {
        get => _isFacingRight;
        set => HandleFieldChange(ref _isFacingRight, value, OnIsFacingRightChanged);
    }

    public Vector2 MovementDirection { get; set; } = Vector3.zero;

    public IWeapon Weapon { get; set; }

    public bool CanAttack { get; set; } = true;

    public float AttackTimerSec { get; set; } = 0F;

    public Vector2 Velocity
    {
        get => _rigidBody.velocity;
        set => _rigidBody.velocity = value;
    }

    public Transform WeaponGripTransform { get; private set; }

    private static void HandleFieldChange<T>(ref T field, T newValue, Action<T> fieldEvent) where T : IEquatable<T>
    {
        var oldValue = field;
        if (Equals(oldValue, newValue)) return;

        field = newValue;
        fieldEvent?.Invoke(newValue);
    }
}