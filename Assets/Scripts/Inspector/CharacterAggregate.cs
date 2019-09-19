using UnityEngine;

//Aggregates various useful components across a character game object.
public class CharacterAggregate : MonoBehaviour
{
    public WeaponView weaponView;
    public Transform weaponTrasnform;
    public Transform weaponGripTransform;
    public BoxCollider2D weaponBoxCollider;

    public CharacterView characterView;
    public Rigidbody2D characterRigidBody;

    public void InjectDependencies(Character character)
    {
        characterView.Construct(character);
    }
}