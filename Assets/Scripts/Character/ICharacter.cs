using UnityEngine;

public interface ICharacter
{
    void Equip(IWeapon weapon);
    void Attack(Vector2 worldPoint);

    void Run(Vector2 direction);
    void Dash();
}