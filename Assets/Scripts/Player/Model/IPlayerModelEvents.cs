using System;

public interface IPlayerModelEvents
{
    event Action<bool> OnIsRunningChanged;
    event Action<bool> OnIsFacingRightChanged;
}