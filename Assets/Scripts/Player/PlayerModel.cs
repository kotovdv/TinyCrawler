using UnityEngine;

public class PlayerModel
{
    public const float Speed = 7.0F;
    public const float JumpSpeed = 21.0F;
    public const float JumpDurationSec = 0.125F;

    public readonly Rigidbody2D RigidBody;

    public bool IsJumping = false;
    public bool IsFacingRight = true;
    public Vector2 MovementDirection = Vector2.zero;
    public Vector2 AfterJumpMovementDirection = Vector2.zero;

    public PlayerModel(Rigidbody2D rigidbody)
    {
        RigidBody = rigidbody;
    }
}