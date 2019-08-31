using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public partial class PlayerView : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    [SerializeField] private Camera cam;
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

    private void HandleFacingDirection(bool isFacingRight)
    {
        spriteRenderer.flipX = !isFacingRight;
    }

    private void HandleRunAnimation(bool isRunning)
    {
        animator.SetBool(IsRunning, isRunning);
    }
}