using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.PlayerInput;

public partial class PlayerView
{
    private void OnRun(InputValue value)
    {
        _movementController.Run(value.Get<Vector2>());
    }

    private void OnDash(InputValue value)
    {
        _movementController.Dash();
    }

    private void OnAttack(InputValue value)
    {
        Debug.Log("asdasd");
        var screenPointPosition = Mouse.current.position.ReadValue();
        var worldPoint = cam.ScreenToWorldPoint(screenPointPosition);
        
        _combatController.Attack(worldPoint);
    }
}