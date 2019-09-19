using System;
using UnityEngine;

public class Character : ICharacter, ICharacterEvents
{
    private CharacterModel _model;
    private CombatMechanics _combatMechanics;
    private MovementMechanics _movementMechanics;

    public Character(
        CharacterModel model,
        CombatMechanics combatMechanics,
        MovementMechanics movementMechanics)
    {
        _model = model;
        _combatMechanics = combatMechanics;
        _movementMechanics = movementMechanics;
    }
    
    public event Action<bool> OnIsRunningChanged
    {
        add => _model.OnIsRunningChanged += value;
        remove => _model.OnIsRunningChanged -= value;
    }

    public event Action<bool> OnIsFacingRightChanged
    {
        add => _model.OnIsFacingRightChanged += value;
        remove => _model.OnIsFacingRightChanged -= value;
    }
    
    public void Equip(IWeapon weapon)
    {
        _combatMechanics.EquipWeapon(_model, weapon);
    }

    public void Attack(Vector2 worldPoint)
    {
        _combatMechanics.Attack(_model, worldPoint);
    }

    public void Run(Vector2 direction)
    {
        _movementMechanics.Run(_model, direction);
    }

    public void Dash()
    {
        _movementMechanics.Dash(_model);
    }
}