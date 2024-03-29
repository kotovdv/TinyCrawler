﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterView : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    [Header("Character settings")]
    [SerializeField] private CharacterScriptableObject characterScriptableObject = default;
    
    [Header("Components settings")]
    [SerializeField] private Animator animator = default;
    [SerializeField] private SpriteRenderer spriteRenderer = default;

    private ICharacterEvents _characterEvents;

    public void Construct(ICharacterEvents characterEvents)
    {
        _characterEvents = characterEvents;
    }

    private void Start()
    {
        DisplayCharacter();
    }

    private void OnValidate()
    {
        DisplayCharacter();
    }

    private void OnEnable()
    {
        _characterEvents.OnIsRunningChanged += HandleRunAnimation;
        _characterEvents.OnIsFacingRightChanged += HandleFacingDirection;
    }

    private void OnDisable()
    {
        _characterEvents.OnIsRunningChanged -= HandleRunAnimation;
        _characterEvents.OnIsFacingRightChanged -= HandleFacingDirection;
    }

    private void HandleFacingDirection(bool isFacingRight)
    {
        transform.rotation = Quaternion.Euler(0, isFacingRight ? 0 : 180, 0);
    }

    private void HandleRunAnimation(bool isRunning)
    {
        animator.SetBool(IsRunning, isRunning);
    }

    private void DisplayCharacter()
    {
        if (characterScriptableObject == null) return;

        animator.runtimeAnimatorController = characterScriptableObject.AnimatorController;
        spriteRenderer.sprite = characterScriptableObject.Sprite;
    }
}