using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private Camera _camera;
    private ICharacter _character;

    public void Construct(Camera cam, ICharacter character)
    {
        _camera = cam;
        _character = character;
    }

    private void OnAttack(InputValue value)
    {
        var screenPosition = Mouse.current.position.ReadValue();
        var worldPosition = _camera.ScreenToWorldPoint(screenPosition);

        _character.Attack(worldPosition);
    }

    private void OnRun(InputValue value)
    {
        _character.Run(value.Get<Vector2>());
    }

    private void OnDash()
    {
        _character.Dash();
    }
}