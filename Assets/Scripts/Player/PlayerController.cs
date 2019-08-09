using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlayerController
{
    private readonly PlayerModel _playerModel;

    [Inject]
    public PlayerController(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void Jump()
    {
        if (_playerModel.IsJumping) return;

        _playerModel.IsJumping = true;
        _playerModel.AfterJumpMovementDirection = _playerModel.MovementDirection;
        _playerModel.RigidBody.velocity = _playerModel.MovementDirection * PlayerModel.JumpSpeed;
        
        AllowJumpDelayed(PlayerModel.JumpDurationSec);
    }

    public void Move(Vector2 direction)
    {
        if (_playerModel.IsJumping)
        {
            _playerModel.AfterJumpMovementDirection = direction;
            return;
        }
        
        _playerModel.MovementDirection = direction;
        _playerModel.RigidBody.velocity = _playerModel.MovementDirection * PlayerModel.Speed;
    }

    private async void AllowJumpDelayed(float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        _playerModel.IsJumping = false;
        Move(_playerModel.AfterJumpMovementDirection);
        _playerModel.AfterJumpMovementDirection = Vector2.zero;
    }
}