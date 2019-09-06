using UnityEngine;
using Zenject;

public class ArenaInstaller : MonoInstaller
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private WeaponScriptableObject defaultWeapon;

    public override void InstallBindings()
    {
        var characterComponents = playerGameObject.GetComponent<CharacterComponents>();

        var playerModel = new PlayerModel(
            characterComponents.HandTransform,
            characterComponents.BodyRigidbody2D
        );

        Container.Bind<Camera>().FromInstance(cam);
        Container.Bind<IPlayerModel>().FromInstance(playerModel);
        Container.Bind<IPlayerModelEvents>().FromInstance(playerModel);

        Container.Bind<PlayerCombatController>().AsSingle();
        Container.Bind<PlayerMovementController>().AsSingle();
        Container.BindInstance(defaultWeapon).WhenInjectedInto<CharacterWeaponView>();
    }
}