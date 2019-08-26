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
        _playerModel = playerModel;
        _playerController = playerController;
    }

    private void OnEnable()
    {
        _playerModel.OnIsRunningChanged += HandleRunAnimation;
        _playerModel.OnIsFacingRightChanged += HandleFacingDirection;
    }

    private void OnDisable()
    {
        _playerModel.OnIsRunningChanged -= HandleRunAnimation;
        _playerModel.OnIsFacingRightChanged -= HandleFacingDirection;
    }

    private void OnMovement(InputValue value)
    {
        _playerController.Move(value.Get<Vector2>());
    }

    private void OnJump(InputValue value)
    {
        _playerController.Jump();
    }

    private void HandleFacingDirection(bool isFacingRight)
    {
        spriteRenderer.flipX = !isFacingRight;
    }

    private void HandleRunAnimation(bool isRunning)
    {
        animator.SetBool(IsRunning, isRunning);
    }
}