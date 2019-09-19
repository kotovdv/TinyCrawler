using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class WeaponView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer = default;
    [SerializeField] private WeaponScriptableObject weaponScriptableObject = default;

    [SerializeField] private Transform weaponTransform = default;
    [SerializeField] private Transform weaponGripTransform = default;
    public WeaponScriptableObject WeaponScriptableObject => weaponScriptableObject;

    private void Start()
    {
        DisplayWeapon();
    }

    private void OnValidate()
    {
        DisplayWeapon();
    }

    private void DisplayWeapon()
    {
        if (weaponScriptableObject == null) return;

        spriteRenderer.sprite = weaponScriptableObject.Sprite;
        weaponGripTransform.localRotation = weaponScriptableObject.GripRotation;
        weaponTransform.localPosition = weaponScriptableObject.GripPosition;
    }
}