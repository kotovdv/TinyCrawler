using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private PlayerModel _playerModel;
    private PlayerController _playerController;

    [Inject]
    public void Construct(PlayerController playerController, PlayerModel playerModel)
    {
        _playerController = playerController;
        _playerModel = playerModel;
    }

    private void OnMovement(InputValue value)
    {
        _playerController.Move(value.Get<Vector2>());
    }

    private void OnJump(InputValue value)
    {
        _playerController.Jump();
    }

    private void Update()
    {
        spriteRenderer.flipX = !_playerModel.IsFacingRight;
    }
}