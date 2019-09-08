using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private BoxCollider2D weaponCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Camera _camera;
    private WeaponScriptableObject _weapon;
    private CombatMechanics _combatMechanics;

    [Inject]
    public void Construct(
        Camera cam,
        WeaponScriptableObject initialWeapon,
        CombatMechanics combatMechanics)
    {
        _camera = cam;
        _weapon = initialWeapon;
        _combatMechanics = combatMechanics;
    }

    private void Awake()
    {
        SetWeapon(_weapon);
    }

    private void OnAttack(InputValue value)
    {
        var screenPosition = Mouse.current.position.ReadValue();
        var worldPosition = _camera.ScreenToWorldPoint(screenPosition);

        _combatMechanics.Attack(worldPosition);
    }

    private void SetWeapon(WeaponScriptableObject weapon)
    {
        spriteRenderer.sprite = weapon.Sprite;
        _combatMechanics.EquipWeapon(new Weapon(weaponTransform, weaponCollider, weapon));
    }
}