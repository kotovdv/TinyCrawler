using System;
using UnityEngine;

public interface ICharacterModelEvents
{
    event Action<bool> OnIsRunningChanged;
    event Action<bool> OnIsFacingRightChanged;
}