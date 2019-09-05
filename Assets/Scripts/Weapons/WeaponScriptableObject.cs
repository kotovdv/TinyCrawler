using ModestTree;
using UnityEngine;

[CreateAssetMenu(menuName = "TinyCrawler/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [Tooltip("Use as an alternative for manual component related settings population")]
    [SerializeField] private GameObject prefab;

    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector2 gripPosition;
    [SerializeField] private Vector3 gripRotation;
    [SerializeField] private Vector2 boxColliderSize;

    public Sprite Sprite => sprite;
    public Vector2 GripPosition => gripPosition;
    public Vector3 GripRotation => gripRotation;
    public Vector2 BoxColliderSize => boxColliderSize;

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