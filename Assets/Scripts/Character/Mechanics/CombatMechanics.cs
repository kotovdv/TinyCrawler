using UnityEngine;

public class CombatMechanics
{
    public static readonly CombatMechanics Instance = new CombatMechanics();

    public void Attack(ICharacterModel character, Vector2 worldPoint)
    {
        if (!character.CanAttack)
            return;

        character.CanAttack = false;
        character.CanChangeFacing = false;
        character.Weapon.Colllider.enabled = true;

        var weaponStats = character.Weapon.Stats;
        //TODO do not allow flipping
        character.IsFacingRight = worldPoint.x >= character.Weapon.GripPosition.position.x;
        Swing(character, worldPoint, weaponStats.SwingDegrees, weaponStats.SwingDurationSec);
    }

    public void EquipWeapon(ICharacterModel character, IWeapon weapon)
    {
        character.Weapon = weapon;
        character.Weapon.Colllider.enabled = false;
        character.Weapon.Colllider.size = weapon.Stats.BoxColliderSize;

        ResetWeaponPosition(character);
    }

    public void ResetWeaponPosition(ICharacterModel character)
    {
        var stats = character.Weapon.Stats;

        character.Weapon.GripPosition.localRotation = stats.GripRotation;
        character.Weapon.Position.localPosition = stats.GripPosition;
    }

    private async void Swing(
        ICharacterModel character,
        Vector2 worldPosition,
        float angle,
        float expectedSwingDurationSec
    )
    {
        var handPosition = character.Weapon.GripPosition;

        var fromUpToCenterRotation = Quaternion.FromToRotation(
            handPosition.InverseTransformDirection(handPosition.up),
            handPosition.InverseTransformPoint(worldPosition).normalized
        );

        var swingCenterRotation = handPosition.localRotation * fromUpToCenterRotation;

        var beforeSwingRotation = swingCenterRotation * Quaternion.Euler(0, 0, angle / 2F);
        var afterSwingRotation = swingCenterRotation * Quaternion.Euler(0, 0, -angle / 2F);

        character.AttackTimerSec = 0;
        while (character.AttackTimerSec < expectedSwingDurationSec)
        {
            handPosition.localRotation = Quaternion.Lerp(
                beforeSwingRotation,
                afterSwingRotation,
                character.AttackTimerSec / expectedSwingDurationSec
            );

            await new WaitForFixedUpdate();

            character.AttackTimerSec += Time.fixedDeltaTime;
        }

        character.CanAttack = true;
        character.CanChangeFacing = true;
        character.Weapon.Colllider.enabled = false;
        ResetWeaponPosition(character);
    }
}