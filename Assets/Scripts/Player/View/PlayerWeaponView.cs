using System;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;
using Debug = UnityEngine.Debug;

public class PlayerWeaponView : MonoBehaviour
{
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private HingeJoint2D joint;
    [SerializeField] private Transform handPosition;
    [SerializeField] private Transform weaponPosition;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Camera _camera;
    private IPlayerModel _playerModel;
    private WeaponScriptableObject _weapon;
    private PlayerCombatController _combatController;
    private float _actualSwingDuration;
    private Stopwatch _stopwatch = new Stopwatch();

    [Inject]
    public void Construct(
        Camera cam,
        IPlayerModel playerModel,
        WeaponScriptableObject initialWeapon,
        PlayerCombatController playerCombatController)
    {
        _camera = cam;
        _playerModel = playerModel;
        _weapon = initialWeapon;
        _combatController = playerCombatController;
    }

    private void Awake()
    {
        SetWeapon(_weapon);
    }

    private void OnAttack(InputValue value)
    {
        ResetWeaponPosition();
        var screenPointPosition = Mouse.current.position.ReadValue();
        var worldPoint = _camera.ScreenToWorldPoint(screenPointPosition);
        _playerModel.IsFacingRight = worldPoint.x >= _playerModel.WorldPosition.x;
        worldPoint.z = 0;
        worldPoint.Normalize();

        Swing(worldPoint, 90, 1.5f);
//        handPosition.Rotate(Vector3.forward, -30);
//        _combatController.Attack(worldPoint);
    }

    private void SetWeapon(WeaponScriptableObject weapon)
    {
        col.enabled = false;
        col.size = weapon.BoxColliderSize;
        spriteRenderer.sprite = weapon.Sprite;

        _playerModel.Weapon = new WeaponModel(col);

        ResetWeaponPosition();
    }

    private void ResetWeaponPosition()
    {
        handPosition.localRotation = Quaternion.Euler(_weapon.GripRotation);
        weaponPosition.localPosition = new Vector3(-_weapon.GripPosition.x, -_weapon.GripPosition.y);
    }


    private async void Swing(Vector3 swingDirection, int angle, float expectedSwingDurationSec)
    {
        var from = Quaternion.Euler(_weapon.GripRotation) * Vector3.up;
        var to = new Vector3(Math.Abs(swingDirection.x), swingDirection.y);

        var swingCenter = handPosition.localRotation * Quaternion.FromToRotation(from, to);

        var beforeSwing = swingCenter * Quaternion.Euler(0, 0, angle / 2F);
        var afterSwing = swingCenter * Quaternion.Euler(0, 0, -angle / 2F);
        
        _actualSwingDuration = 0;
        while (_actualSwingDuration < expectedSwingDurationSec)
        {
            handPosition.localRotation = Quaternion.Lerp(
                beforeSwing,
                afterSwing,
                _actualSwingDuration / expectedSwingDurationSec
            );
            await new WaitForFixedUpdate();

            _actualSwingDuration += Time.fixedDeltaTime;
        }

        ResetWeaponPosition();
    }
}