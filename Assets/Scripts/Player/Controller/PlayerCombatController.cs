using UnityEngine;

public class PlayerCombatController
{
    private readonly IPlayerModel _character;

    public PlayerCombatController(IPlayerModel character)
    {
        _character = character;
    }

    public void Attack(Vector2 worldPoint)
    {
        if (!_character.CanAttack)
            return;

        _character.CanAttack = false;

        var weaponStats = _character.Weapon.Stats;
        //TODO do not allow flipping
        _character.IsFacingRight = worldPoint.x >= _character.HandPosition.position.x;
        Swing(worldPoint.normalized, weaponStats.SwingDegrees, weaponStats.SwingDurationSec);
    }

    public void EquipWeapon(IWeapon weapon)
    {
        //TODO prb replace whole prefab
        _character.Weapon = weapon;
        _character.Weapon.Colllider.enabled = true;
        _character.Weapon.Colllider.size = weapon.Stats.BoxColliderSize;

        ResetWeaponPosition();
    }

    private void ResetWeaponPosition()
    {
        var stats = _character.Weapon.Stats;

        _character.HandPosition.localRotation = stats.GripRotation;
        _character.Weapon.Position.localPosition = stats.GripPosition;
    }

    private async void Swing(Vector2 swingDirection, float angle, float expectedSwingDurationSec)
    {
        var handPosition = _character.HandPosition;

        var fromUpToCenterRotation = Quaternion.FromToRotation(
            handPosition.InverseTransformDirection(handPosition.up),
            handPosition.InverseTransformDirection(swingDirection)
        );

        var swingCenterRotation = handPosition.localRotation * fromUpToCenterRotation;

        var beforeSwingRotation = swingCenterRotation * Quaternion.Euler(0, 0, angle / 2F);
        var afterSwingRotation = swingCenterRotation * Quaternion.Euler(0, 0, -angle / 2F);

        _character.AttackTimerSec = 0;
        while (_character.AttackTimerSec < expectedSwingDurationSec)
        {
            await new WaitForFixedUpdate();

            handPosition.localRotation = Quaternion.Lerp(
                beforeSwingRotation,
                afterSwingRotation,
                _character.AttackTimerSec / expectedSwingDurationSec
            );

            _character.AttackTimerSec += Time.fixedDeltaTime;
        }

        _character.CanAttack = true;
        ResetWeaponPosition();
    }
}