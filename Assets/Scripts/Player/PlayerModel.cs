using UnityEngine;
using Zenject;

public class PlayerModel
{
    public readonly float Speed = 7.5f;
    public readonly Rigidbody2D RigidBody;

    [Inject]
    public PlayerModel(Rigidbody2D rigidbody)
    {
        RigidBody = rigidbody;
    }
}