using System;

public interface ICharacterEvents
{
    event Action<bool> OnIsRunningChanged;
    event Action<bool> OnIsFacingRightChanged;
}