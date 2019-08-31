using System;
using ModestTree;
using UnityEngine;

[CreateAssetMenu(menuName = "TinyCrawler/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector2 gripPosition;
    [SerializeField] private Vector2 boxColliderSize;

    //As an alternative to manual component related settings population
    [SerializeField] private GameObject prefab;
    
    public Sprite Sprite => sprite;
    public Vector2 GripPosition => gripPosition;
    public Vector2 BoxColliderSize => boxColliderSize;
    
    private void OnValidate()
    {
        var grip = prefab.transform.Find("Grip");
        var weaponBoxCollider2D = prefab.GetComponent<BoxCollider2D>();
        var weaponSpriteRenderer = prefab.GetComponent<SpriteRenderer>();

        Assert.IsNotNull(grip, "Grip is missing");
        Assert.IsNotNull(weaponBoxCollider2D, "Weapon BoxCollider is missing");
        Assert.IsNotNull(weaponSpriteRenderer, "Weapon SpriteRenderer is missing");

        sprite = weaponSpriteRenderer.sprite;
        gripPosition = grip.transform.position;
        boxColliderSize = weaponBoxCollider2D.size;
    }
}