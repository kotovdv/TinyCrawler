using System.Diagnostics;
using UnityEngine;

public class WeaponModel
{
    public const int SwingDegrees = 75;
    public const float SwingTimeSec = 0.175F;

    public readonly BoxCollider2D BoxCollider;
    public readonly Stopwatch AttackStopWatch = new Stopwatch();

    public WeaponModel(BoxCollider2D boxCollider)
    {
        BoxCollider = boxCollider;
    }
}