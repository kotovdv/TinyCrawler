using UnityEngine;

public interface IWeapon
{
    Transform Position { get; }
    BoxCollider2D Colllider { get; }
    
    IWeaponStats Stats { get; }
}