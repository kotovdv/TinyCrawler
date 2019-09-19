using System;
using System.Threading.Tasks;
using UnityEngine;

public class MovementMechanics
{
    public static readonly MovementMechanics Instance = new MovementMechanics();
    
    public void Run(ICharacterModel model, Vector2 direction)
    {
        model.MovementDirection = direction.normalized;

        if (model.IsDashing) return;

        model.Velocity = model.MovementDirection * model.Speed;
        model.IsRunning = Math.Abs(model.Velocity.magnitude) > Mathf.Epsilon;

        if (model.IsRunning && model.CanChangeFacing)
        {
            model.IsFacingRight = model.Velocity.x > 0;
        }
    }

    public void Dash(ICharacterModel model)
    {
        if (model.IsDashing) return;

        model.IsDashing = true;

        var dashDirection = model.MovementDirection;
        if (dashDirection == Vector2.zero)
        {
            dashDirection = model.IsFacingRight
                ? Vector2.right
                : Vector2.left;
        }

        model.Velocity = dashDirection * model.DashSpeed;

        AllowDashDelayed(model, model.DashDurationSec);
    }

    private async void AllowDashDelayed(ICharacterModel model, float delaySeconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));

        model.IsDashing = false;
        Run(model, model.MovementDirection);
    }
}