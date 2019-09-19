using UnityEngine;

public class Weapon : IWeapon
{
    public Transform Position { get; }
    public Transform GripPosition { get; }
    public IWeaponStats Stats { get; }
    public BoxCollider2D Colllider { get; }

    public Weapon
    (
        Transform position,
        Transform gripPosition,
        BoxCollider2D boxCollider2D,
        IWeaponStats stats)
    {
        Position = position;
        GripPosition = gripPosition;
        Colllider = boxCollider2D;
        Stats = stats;
    }
}