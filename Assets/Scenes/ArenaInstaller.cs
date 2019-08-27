using UnityEngine;
using Zenject;

public class ArenaInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerGameObject;
    
    public override void InstallBindings()
    {
        var playerModel = new PlayerModel(playerGameObject.GetComponent<Rigidbody2D>());
        
        Container.Bind<PlayerModel>().FromInstance(playerModel);
        
        Container.Bind<PlayerCombatController>().AsSingle();
        Container.Bind<PlayerMovementController>().AsSingle();
    }
}