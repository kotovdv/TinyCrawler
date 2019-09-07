using UnityEngine;

public class Character : ICharacter
{
    private readonly CombatMechanics _combatMechanics;
    private readonly MovementMechanics _movementMechanics;

    public Character
    (
        CombatMechanics combatMechanics,
        MovementMechanics movementMechanics
    )
    {
        _combatMechanics = combatMechanics;
        _movementMechanics = movementMechanics;
    }

    public void Equip(IWeapon weapon)
    {
        _combatMechanics.EquipWeapon(weapon);
    }

    public void Attack(Vector2 worldPoint)
    {
        _combatMechanics.Attack(worldPoint);
    }

    public void Run(Vector2 direction)
    {
        _movementMechanics.Run(direction);
    }

    public void Dash()
    {
        _movementMechanics.Dash();
    }
}