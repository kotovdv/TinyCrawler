using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovementController
{
    private readonly IPlayerModel _playerModel;

    public PlayerMovementController(IPlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void Run(Vector2 direction)
    {
        _playerModel.MovementDirection = direction;

        if (_playerModel.IsDashing) return;

        _playerModel.Velocity = _playerModel.MovementDirection * _playerModel.Speed;
        _playerModel.IsRunning = Math.Abs(_playerModel.Velocity.magnitude) > Mathf.Epsilon;
        if (_playerModel.IsRunning)
        {
            _playerModel.IsFacingRight = _playerModel.Velocity.x > 0;
        }
    }

    public void Dash()
    {
        if (_playerModel.IsDashing) return;

        _playerModel.IsDashing = true;
        
        var dashDirection = _playerModel.MovementDirection;
        if (dashDirection == Vector2.zero)
        {
            dashDirection = _playerModel.IsFacingRight
                ? Vector2.right
                : Vector2.left;
        }

        _playerModel.Velocity = dashDirection * _playerModel.DashSpeed;

        AllowDashDelayed(_playerModel.DashDurationSec);
    }

    private async void AllowDashDelayed(float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        _playerModel.IsDashing = false;
        Run(_playerModel.MovementDirection);
    }
}