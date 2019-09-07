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

        var playerModel = new CharacterModel(
            characterComponents.HandTransform,
            characterComponents.BodyRigidbody2D
        );

        Container.Bind<Camera>().FromInstance(cam);
        Container.Bind<ICharacterModel>().FromInstance(playerModel);
        Container.Bind<ICharacterModelEvents>().FromInstance(playerModel);

        Container.Bind<CombatMechanics>().AsSingle();
        Container.Bind<MovementMechanics>().AsSingle();
        Container.BindInstance(defaultWeapon).WhenInjectedInto<CharacterWeaponView>();
    }
}