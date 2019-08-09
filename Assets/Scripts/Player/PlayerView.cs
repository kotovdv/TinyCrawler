using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

public class PlayerView : MonoBehaviour
{
    private PlayerController _playerController;

    [Inject]
    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void OnMovement(InputValue value)
    {
        _playerController.Move(value.Get<Vector2>());
    }

    public void OnJump(InputValue value)
    {
        _playerController.Jump();
    }
}