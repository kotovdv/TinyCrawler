using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterView : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ICharacterModelEvents _characterModelEvents;

    private MovementMechanics _movementMechanics;

    [Inject]
    public void Construct(
        MovementMechanics movementMechanics,
        ICharacterModelEvents characterModelEvents
    )
    {
        _movementMechanics = movementMechanics;
        _characterModelEvents = characterModelEvents;
    }

    private void OnEnable()
    {
        _characterModelEvents.OnIsRunningChanged += HandleRunAnimation;
        _characterModelEvents.OnIsFacingRightChanged += HandleFacingDirection;
    }

    private void OnDisable()
    {
        _characterModelEvents.OnIsRunningChanged -= HandleRunAnimation;
        _characterModelEvents.OnIsFacingRightChanged -= HandleFacingDirection;
    }

    private void OnRun(InputValue value)
    {
        _movementMechanics.Run(value.Get<Vector2>());
    }

    private void OnDash(InputValue value)
    {
        _movementMechanics.Dash();
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