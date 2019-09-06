using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    [SerializeField] private Transform _handTransform;
    [SerializeField] private Rigidbody2D _bodyRigidbody2D;

    public Transform HandTransform => _handTransform;
    public Rigidbody2D BodyRigidbody2D => _bodyRigidbody2D;
}