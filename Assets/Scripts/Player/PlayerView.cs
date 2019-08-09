using UnityEngine;
using UnityEngine.InputSystem.PlayerInput;
using Zenject;

public class PlayerView : MonoBehaviour
{
    private PlayerController PlayerController { get; set; }

    [Inject]
    public void Construct(PlayerController playerController)
    {
        PlayerController = playerController;
    }

    public void OnMovement(InputValue value)
    {
        PlayerController.SetMovementDirection(value.Get<Vector2>());
    }
}