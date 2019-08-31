using UnityEngine;

public interface IPlayerModel
{
    float Speed { get; }
    float DashSpeed { get; }
    float DashDurationSec { get; }

    bool IsDashing { get; set; }
    bool IsRunning { get; set; }
    bool IsFacingRight { get; set; }
    Vector2 Velocity { get; set; }
    Vector2 MovementDirection { get; set; }
}