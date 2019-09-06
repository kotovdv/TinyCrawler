using UnityEngine;

public class Weapon : IWeapon
{
    public Transform Position { get; }
    public IWeaponStats Stats { get; }
    public BoxCollider2D Colllider { get; }

    public Weapon
    (
        Transform position,
        BoxCollider2D boxCollider2D,
        IWeaponStats stats)
    {
        Position = position;
        Colllider = boxCollider2D;
        Stats = stats;
    }
}