using UnityEngine;
using UnityEngine.Serialization;

public class BladeMovement : MonoBehaviour
{
    private const float Speed = 5.0f;

    [SerializeField] private Vector2 direction = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime * direction, Space.World);
    }
}