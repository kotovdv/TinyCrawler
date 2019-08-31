using System;
using UnityEngine;
using Zenject;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private WeaponScriptableObject weaponScriptableObject;

    private IPlayerModel _playerModel;
    private IPlayerModelEvents _playerModelEvents;

    [Inject]
    public void Construct(
        IPlayerModel playerModel,
        IPlayerModelEvents playerModelEvents)
    {
        _playerModel = playerModel;
        _playerModelEvents = playerModelEvents;
    }

    private void Awake()
    {
        SetWeapon(weaponScriptableObject);
    }

    private void OnEnable()
    {
        _playerModelEvents.OnIsFacingRightChanged += HandleFacingDirectionChange;
    }

    private void OnDisable()
    {
        _playerModelEvents.OnIsFacingRightChanged -= HandleFacingDirectionChange;
    }

    private void SetWeapon(WeaponScriptableObject weapon)
    {
        col.size = weapon.BoxColliderSize;
        spriteRenderer.sprite = weapon.Sprite;

        var position = transform.position;

        transform.position = new Vector3(
            position.x - weapon.GripPosition.x,
            position.y - weapon.GripPosition.y
        );

        HandleFacingDirectionChange(_playerModel.IsFacingRight);
    }

    private void HandleFacingDirectionChange(bool isFacingRight)
    {
        var position = transform.localPosition;

        transform.localPosition = new Vector3(
            Math.Abs(position.x) * (isFacingRight ? 1 : -1),
            position.y
        );

        spriteRenderer.flipX = !isFacingRight;
    }
}