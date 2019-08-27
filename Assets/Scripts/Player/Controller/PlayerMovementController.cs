using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovementController
{
    private readonly PlayerModel _playerModel;

    public PlayerMovementController(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void Run(Vector2 direction)
    {
        _playerModel.MovementDirection = direction.normalized;

        if (_playerModel.IsDashing) return;

        _playerModel.Velocity = _playerModel.MovementDirection * PlayerModel.Speed;
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
        _playerModel.Velocity = _playerModel.MovementDirection * PlayerModel.DashSpeed;

        AllowDashDelayed(PlayerModel.DashDurationSec);
    }

    private async void AllowDashDelayed(float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        _playerModel.IsDashing = false;
        Run(_playerModel.MovementDirection);
    }
}