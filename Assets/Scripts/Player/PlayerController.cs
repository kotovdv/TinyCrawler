using System.Collections;
using System.Collections.Generic;
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

    public void SetMovementDirection(Vector2 direction)
    {
        _playerModel.RigidBody.velocity = direction * _playerModel.Speed;
    }
}