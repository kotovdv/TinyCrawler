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

    private void OnEnable()
    {
        UpdateLookDirection(_playerModel.IsFacingRight);
        _playerModel.OnIsFacingRightChanged += UpdateLookDirection;
    }

    private void OnDisable()
    {
        _playerModel.OnIsFacingRightChanged -= UpdateLookDirection;
    }

    private void OnMovement(InputValue value)
    {
        _playerController.Move(value.Get<Vector2>());
    }

    private void OnJump(InputValue value)
    {
        _playerController.Jump();
    }

    private void UpdateLookDirection(bool isFacingRight)
    {
        spriteRenderer.flipX = !isFacingRight;
    }
}