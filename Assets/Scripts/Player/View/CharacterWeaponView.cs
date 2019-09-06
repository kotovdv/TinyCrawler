using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

public class CharacterWeaponView : MonoBehaviour
{
    [SerializeField] private Transform weaponTransform;
    [SerializeField] private BoxCollider2D weaponCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Camera _camera;
    private WeaponScriptableObject _weapon;
    private PlayerCombatController _combatController;

    [Inject]
    public void Construct(
        Camera cam,
        WeaponScriptableObject initialWeapon,
        PlayerCombatController playerCombatController)
    {
        _camera = cam;
        _weapon = initialWeapon;
        _combatController = playerCombatController;
    }

    private void Awake()
    {
        SetWeapon(_weapon);
    }

    private void OnAttack(InputValue value)
    {
        var screenPosition = Mouse.current.position.ReadValue();
        var worldPosition = _camera.ScreenToWorldPoint(screenPosition);

        _combatController.Attack(worldPosition);
    }

    private void SetWeapon(WeaponScriptableObject weapon)
    {
        spriteRenderer.sprite = weapon.Sprite;
        _combatController.EquipWeapon(new Weapon(weaponTransform, weaponCollider, weapon));
    }
}