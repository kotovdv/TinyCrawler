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

    private IPlayerModelEvents _playerModelEvents;
    private PlayerCombatController _combatController;
    private PlayerMovementController _movementController;

    [Inject]
    public void Construct(
        IPlayerModelEvents playerModelEvents,
        PlayerCombatController combatController,
        PlayerMovementController movementController
    )
    {
        _playerModelEvents = playerModelEvents;
        _combatController = combatController;
        _movementController = movementController;
    }

    private void OnEnable()
    {
        _playerModelEvents.OnIsRunningChanged += HandleRunAnimation;
        _playerModelEvents.OnIsFacingRightChanged += HandleFacingDirection;
    }

    private void OnDisable()
    {
        _playerModelEvents.OnIsRunningChanged -= HandleRunAnimation;
        _playerModelEvents.OnIsFacingRightChanged -= HandleFacingDirection;
    }
    
    private void OnRun(InputValue value)
    {
        _movementController.Run(value.Get<Vector2>());
    }

    private void OnDash(InputValue value)
    {
        _movementController.Dash();
    }

    private void HandleFacingDirection(bool isFacingRight)
    {
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }

    private void HandleRunAnimation(bool isRunning)
    {
        animator.SetBool(IsRunning, isRunning);
    }
}