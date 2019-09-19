using System.Collections.Generic;
using UnityEngine;

public class SceneInstaller : MonoBehaviour
{
    [SerializeField] private Camera cam = default;
    [SerializeField] private PlayableCharacterAggregate player = default;
    [SerializeField] private List<CharacterAggregate> otherCharacters = default;

    private void Awake()
    {
        var character = CreateCharacter(player.characterAggregate);
        player.InjectDependencies(cam, character);

        foreach (var currentAggregate in otherCharacters)
        {
            var currentCharacter = CreateCharacter(currentAggregate);
            currentAggregate.InjectDependencies(currentCharacter);
        }
    }

    private Character CreateCharacter(CharacterAggregate aggregate)
    {
        var weapon = new Weapon(aggregate.weaponTrasnform,
            aggregate.weaponGripTransform,
            aggregate.weaponBoxCollider,
            aggregate.weaponView.WeaponScriptableObject
        );

        var model = new CharacterModel(
            aggregate.weaponGripTransform,
            aggregate.characterRigidBody,
            weapon
        );

        return new Character(model, CombatMechanics.Instance, MovementMechanics.Instance);
    }
}