using UnityEngine;

//Aggregates various useful components across a playable character game object.
public class PlayableCharacterAggregate : MonoBehaviour
{
    public CharacterController controller;
    public CharacterAggregate characterAggregate;

    public void InjectDependencies(Camera cam, Character character)
    {
        controller.Construct(cam, character);
        characterAggregate.InjectDependencies(character);
    }
}