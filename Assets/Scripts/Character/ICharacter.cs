using UnityEngine;

public interface ICharacter
{
    void Run(Vector2 direction);
    void Dash();
    
    void Equip(IWeapon weapon);
    void Attack(Vector2 worldPoint);
}