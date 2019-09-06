using UnityEngine;

public interface IPlayerModel
{
    float Speed { get; }
    float DashSpeed { get; }
    float DashDurationSec { get; }

    bool IsDashing { get; set; }
    bool IsRunning { get; set; }
    bool CanChangeFacing { get; set; }
    bool IsFacingRight { get; set; }

    Vector2 Velocity { get; set; }
    Vector2 MovementDirection { get; set; }

    IWeapon Weapon { get; set; }
    Transform HandPosition { get; }

    bool CanAttack { get; set; }
    float AttackTimerSec { get; set; }
}