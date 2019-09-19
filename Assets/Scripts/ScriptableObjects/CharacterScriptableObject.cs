using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "TinyCrawler/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite sprite = default;
    [SerializeField] private RuntimeAnimatorController animatorController = default;

    public Sprite Sprite => sprite;
    public RuntimeAnimatorController AnimatorController => animatorController;
}