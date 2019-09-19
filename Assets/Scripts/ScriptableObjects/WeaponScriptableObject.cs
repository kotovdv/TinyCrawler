using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu(menuName = "TinyCrawler/Weapon")]
public class WeaponScriptableObject : ScriptableObject, IWeaponStats
{
    [Tooltip("Use as an alternative for manual component related settings population")]
    [SerializeField] private GameObject prefab = default;

    [SerializeField] private Sprite sprite = default;
    [SerializeField] private Vector2 gripPosition = default;
    [SerializeField] private Vector3 gripRotation = default;
    [SerializeField] private Vector2 boxColliderSize = default;

    [SerializeField] private float swingDegrees = default;
    [SerializeField] private float swingDurationSec = default;

    public Sprite Sprite => sprite;
    public Vector2 GripPosition => -gripPosition;
    public Quaternion GripRotation => Quaternion.Euler(gripRotation);
    public Vector2 BoxColliderSize => boxColliderSize;
    public float SwingDegrees => swingDegrees;
    public float SwingDurationSec => swingDurationSec;

    private void OnValidate()
    {
        var grip = prefab.transform.Find("Grip");
        var weaponBoxCollider2D = prefab.GetComponent<BoxCollider2D>();
        var weaponSpriteRenderer = prefab.GetComponent<SpriteRenderer>();

        Assert.IsNotNull(grip, "Grip is missing");
        Assert.IsNotNull(weaponBoxCollider2D, "Weapon BoxCollider is missing");
        Assert.IsNotNull(weaponSpriteRenderer, "Weapon SpriteRenderer is missing");

        var gripTransform = grip.transform;

        sprite = weaponSpriteRenderer.sprite;
        gripPosition = gripTransform.position;
        boxColliderSize = weaponBoxCollider2D.size;
        gripRotation = gripTransform.rotation.eulerAngles;
    }
}