using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bodyRigidbody2D;
    
    public Rigidbody2D BodyRigidbody2D => _bodyRigidbody2D;
}