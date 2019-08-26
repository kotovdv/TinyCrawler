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
        _playerModel.MovementDirection = direction;

        if (_playerModel.IsDashing) return;

        if (Math.Abs(direction.x - 0) > Mathf.Epsilon)
        {
            _playerModel.IsFacingRight = _playerModel.MovementDirection.x > 0;
        }

        _playerModel.Velocity = _playerModel.MovementDirection * PlayerModel.Speed;
        _playerModel.IsRunning = Math.Abs(_playerModel.Velocity.magnitude - 0) > Mathf.Epsilon;
    }

    public void Dash()
    {
        if (_playerModel.IsDashing) return;

        _playerModel.IsDashing = true;
        _playerModel.Velocity = _playerModel.MovementDirection * PlayerModel.JumpSpeed;

        AllowDashDelayed(PlayerModel.JumpDurationSec);
    }

    private async void AllowDashDelayed(float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        _playerModel.IsDashing = false;
        Run(_playerModel.MovementDirection);
    }
}