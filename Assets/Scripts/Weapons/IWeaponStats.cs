using UnityEngine;

public interface IWeaponStats
{
    float SwingDegrees { get; }
    float SwingDurationSec { get; }

    Vector2 GripPosition { get; }
    Quaternion GripRotation { get; }
    
    Vector2 BoxColliderSize { get; }
}