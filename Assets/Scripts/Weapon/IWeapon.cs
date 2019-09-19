using UnityEngine;

public interface IWeapon
{
    Transform Position { get; }
    Transform GripPosition { get; }
    BoxCollider2D Colllider { get; }
    IWeaponStats Stats { get; }

}