using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCombatController
{
    private readonly IPlayerModel _playerModel;

    public PlayerCombatController(IPlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void Attack(Vector2 position)
    {
        if (_playerModel.IsAttacking)
            return;

        _playerModel.IsAttacking = true;
    }

    private async void AllowAttackDelayed(float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        _playerModel.IsAttacking = false;
    }
    
    
    private void ResetWeaponPosition(WeaponScriptableObject weapon)
    {
        /*handPosition.rotation = Quaternion.identity;
        var handPos = handPosition.position;

        weaponPosition.position = new Vector3(
            handPos.x - weapon.GripPosition.x,
            handPos.y - weapon.GripPosition.y
        );*/

//        handPosition.rotation = Quaternion.Euler(weapon.GripRotation);
    }

    private async void Swing(Vector3 swingDirection, int angle, float durationSec)
    {
        /*var halfAngle = Math.Abs(angle) / 2f;

        var faceModifier = _playerModel.IsFacingRight ? 1 : -1;
        var from = Quaternion.Euler(0, 0, (faceModifier * halfAngle)) * swingDirection;
        var to = Quaternion.Euler(0, 0, -(faceModifier * halfAngle)) * swingDirection;

        var stopwatch = Stopwatch.StartNew();

        while (stopwatch.Elapsed.TotalSeconds < durationSec)
        {
            var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            var durationFraction = (float) elapsedTotalSeconds / durationSec;

            Quaternion.FromToRotation()
                Quaternion.RotateTowards()
            handPosition.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.Slerp(from, to, durationFraction));

            await new WaitForUpdate();
        }

        ResetWeaponPosition(_currentWeapon);*/
    }
}