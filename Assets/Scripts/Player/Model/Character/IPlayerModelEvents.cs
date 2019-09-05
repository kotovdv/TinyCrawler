using System;
using UnityEngine;

public interface IPlayerModelEvents
{
    event Action<bool> OnIsRunningChanged;
    event Action<bool> OnIsFacingRightChanged;
    event Action<Vector2> OnPlayerAttackedInDirection;
}