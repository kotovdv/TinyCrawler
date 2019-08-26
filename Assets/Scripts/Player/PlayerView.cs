using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    
    [SerializeField] private Animator animator;
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
        HandleLookDirection(_playerModel.IsFacingRight);
        _playerModel.OnIsRunningChanged += HandleRunAnimation;
        _playerModel.OnIsFacingRightChanged += HandleLookDirection;
    }

    private void OnDisable()
    {
        _playerModel.OnIsFacingRightChanged -= HandleLookDirection;
    }

    private void OnMovement(InputValue value)
    {
        _playerController.Move(value.Get<Vector2>());
    }

    private void OnJump(InputValue value)
    {
        _playerController.Jump();
    }

    private void HandleLookDirection(bool isFacingRight)
    {
        spriteRenderer.flipX = !isFacingRight;
    }

    private void HandleRunAnimation(bool isRunning)
    {
        animator.SetBool(IsRunning, isRunning);
    }
}