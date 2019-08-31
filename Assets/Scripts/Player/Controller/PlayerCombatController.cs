using UnityEngine;

public class PlayerCombatController
{
    private readonly IPlayerModel _playerModel;

    public PlayerCombatController(IPlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void Attack(Vector2 position)
    {
        
    }
}