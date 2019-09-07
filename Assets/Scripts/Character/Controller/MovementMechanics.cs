using System;
using System.Threading.Tasks;
using UnityEngine;

public class MovementMechanics
{
    private readonly ICharacterModel _characterModel;

    public MovementMechanics(ICharacterModel characterModel)
    {
        _characterModel = characterModel;
    }

    public void Run(Vector2 direction)
    {
        _characterModel.MovementDirection = direction.normalized;

        if (_characterModel.IsDashing) return;

        _characterModel.Velocity = _characterModel.MovementDirection * _characterModel.Speed;
        _characterModel.IsRunning = Math.Abs(_characterModel.Velocity.magnitude) > Mathf.Epsilon;
        
        if (_characterModel.IsRunning && _characterModel.CanChangeFacing)
        {
            _characterModel.IsFacingRight = _characterModel.Velocity.x > 0;
        }
    }

    public void Dash()
    {
        if (_characterModel.IsDashing) return;

        _characterModel.IsDashing = true;

        var dashDirection = _characterModel.MovementDirection;
        if (dashDirection == Vector2.zero)
        {
            dashDirection = _characterModel.IsFacingRight
                ? Vector2.right
                : Vector2.left;
        }

        _characterModel.Velocity = dashDirection * _characterModel.DashSpeed;

        AllowDashDelayed(_characterModel.DashDurationSec);
    }

    private async void AllowDashDelayed(float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        _characterModel.IsDashing = false;
        Run(_characterModel.MovementDirection);
    }
}